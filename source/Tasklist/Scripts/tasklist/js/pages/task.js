$(document).ready(function () {
    if ($('#demo-table').val() != undefined)
        $('#demo-table').bootstrapTable();
});

(function () {
    function Task() { };
    Task.prototype = {

        submit: function () {
            var action = $('input#Id').val() == "0" ? "/Task/Create" : "/Task/Edit";
            $("#form").attr('action', action);
        },

        newTask: function (row) {
            $("input#Id").attr('value', 0);
            $("input#Title").val("");
            $("textarea#Description").val("");
            $("input#Completed").prop('checked', false);
        },

        editTask: function (row) {
            $("input#Id").attr('value', row.id);
            $("input#Title").val(row.title);
            $("textarea#Description").val(row.description);
            $("input#Completed").prop('checked', row.completed);
        },

        deleteTask: function (row) {
            if (confirm("Deseja realmente excluir a tarefa?")) {
                $.ajax({
                    type: "POST",
                    url: "/Task/Delete",
                    data: { id: row.id },
                    success: function (success) {
                        $("#demo-table").bootstrapTable('refresh');
                    }
                });
            }
        },

        saveTask: function (id) {
            var me = this;
            $(".modal-dialog").loadMask("Processando...");

            if (!$("#txtTaskTitle").val() || !$("#txtTaskDescription").val()) {
                bootbox.alert({ message: "<h4 class='text-thin'>Salvar</h4><p>Informe os campos obrigatórios corretamente!</p>" });
                $(".modal-dialog").unloadMask();
                return
            }

            var callback = function (data) {
                if (data.success) {
                    $("#taskForm").parents(".modal").modal("toggle");
                    $.niftyNoty({
                        type: data.success ? "success" : "danger",
                        icon: "fa fa-thumbs-" + (data.success ? "up" : "down") + " fa-lg",
                        title: "Tarefa",
                        message: data.success ? "Dados salvos com sucesso!" : data.msg,
                        container: "floating",
                        timer: 3500
                    });
                    me.loadTasks();
                }
                else {
                    bootbox.alert({ message: "<h4 class='text-thin'>Salvar</h4><p>" + data.msg + "</p>" });
                    $(".modal-dialog").unloadMask();
                }

            };

            NiftyApp.saveData("taskForm", callback);
        },

        completedFormatter: function (value, row, index) {
            var returnText = "";

            if (value)
                returnText = "Concluída";

            return returnText;
        },

        actionFormatter: function (value, row, index) {

            var action = '' +
                '<span class=\"my-table-actions">' +
                '<a class="fa fa-edit" title="Editar" onclick="Task.editTask({ id: ' + row.Id + ', title: \'' + row.Title + '\', description: \'' + row.Description + '\', completed: ' + row.Completed + ' })"></a>' +
                '<a class="fa fa-remove" style="color:#F00" title="Excluir" onclick="Task.deleteTask({ id: ' + value + ' })"></a>' +
                '</span>';
            return action;
        }
    }

    this['Task'] = new Task();
}).call(this);