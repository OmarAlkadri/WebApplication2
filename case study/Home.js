$(document).ready(function () {
    const endPoint = "https://localhost:7236/api/Student/AllStudent";
    $.ajax({
        url: endPoint,
        type: "GET",
        success: function (result) {
            generateTable(result);
            console.log(result);
        },
        error: function (error) {
            console.log(`Error ${error}`);
        }
    });
});
var datas;
function generateTable(data) {
    datas = data;
    for (let element of data) {
        $(".data-table tbody").append(
            "<tr class='fadetext' data-name='" + element['name'] + "' data-lastname='" + element['lastName'] + "' data-vize='" + element['vize'] + "' data-final='" + element['final'] + "' data-Id='" + element['id']
            + "'><td><input type='checkbox' id='select-row'></td>'+' <td>" + element['name'] + "</td><td>" + element['lastName'] + "</td><td>" + element['vize'] + "</td><td>" + element['final'] +
            '</td><td><button class="btn btn-info btn-xs btn-edit">Edit</button><button class="btn btn-danger btn-xs btn-delete">Delete</button></td></tr>');
    }
}

$("body").on("click", ".btn-edit", function () {
    var Id = $(this).parents("tr").attr('data-Id');
    var name = $(this).parents("tr").attr('data-name');
    var lastName = $(this).parents("tr").attr('data-lastName');
    var vize = $(this).parents("tr").attr('data-vize');
    var final = $(this).parents("tr").attr('data-final');

    $(this).parents("tr").find("td:eq(1)").html('<input name="edit_name" value="' + name + '">');
    $(this).parents("tr").find("td:eq(2)").html('<input name="edit_lastName" value="' + lastName + '">');
    $(this).parents("tr").find("td:eq(3)").html('<input name="edit_vize" value="' + vize + '">');
    $(this).parents("tr").find("td:eq(4)").html('<input name="edit_final" value="' + final + '">');

    $(this).parents("tr").find("td:eq(5)").prepend("<button class='btn btn-info btn-xs btn-update'>Update</button><button class='btn btn-warning btn-xs btn-cancel'>Cancel</button>")
    $(this).hide();
});

$("body").on("click", ".btn-update", function () {
    var name = $(this).parents("tr").find("input[name='edit_name']").val();
  //  var lastName = $(this).parent().parent().find("input[name='edit_lastName']").val();

    
    var lastName = $(this).parents("tr").find("input[name='edit_lastName']").val();
    var vize = $(this).parents("tr").find("input[name='edit_vize']").val();
    var final = $(this).parents("tr").find("input[name='edit_final']").val();

 
    var Id = $(this).parents("tr").attr('data-Id');


    const student = {
        name: name,
        lastName: lastName,
        vize: vize,
        final: final
    }
    const endPoint = `https://localhost:7236/api/Student/${Id}`;

    console.log(student);

    $.ajax({
        url: endPoint,
        type: "PUT",
        data: JSON.stringify(student),
        success: function (result) {
            console.log(result);
        },
        contentType: "application/json",
        dataType: 'json',
        error: function (error) {
            console.log(`Error ${error}`);
        }
    });



    $(this).parents("tr").find("td:eq(1)").text(name);
    $(this).parents("tr").find("td:eq(2)").text(lastName);
    $(this).parents("tr").find("td:eq(3)").text(vize);
    $(this).parents("tr").find("td:eq(4)").text(final);

    $(this).parents("tr").attr('data-name', name);
    $(this).parents("tr").attr('data-edit_lastName', lastName);
    $(this).parents("tr").attr('data-edit_vize', vize);
    $(this).parents("tr").attr('data-edit_final', final);

    $(this).parents("tr").find(".btn-edit").show();
    $(this).parents("tr").find(".btn-cancel").remove();
    $(this).parents("tr").find(".btn-update").remove();
});


$(document).ready(function () {
    $("#add-row").click(function () {
        var name = $("#firstname").val();
        var lastname = $("#lastname").val();
        var Vize = $("#Vize").val();
        var Final = $("#Final").val();

        const student = {
            name: name,
            lastName: lastname,
            vize: Vize,
            final: Final
        }
        const endPoint = "https://localhost:7236/api/Student/Add";

        $.ajax({
            url: endPoint,
            type: "POST",
            data: JSON.stringify(student),
            success: function (result) {
                console.log(result);
            },
            contentType: "application/json",
            dataType: 'json',
            error: function (error) {
                console.log(`Error ${error}`);
            }
        });


        $(".data-table tbody").append(
            "<tr class='fadetext' data-name='" + name + "' data-lastname='" + lastname + "' data-vize='" + Vize + "' data-final='" + Final
            + "'><td><input type='checkbox' id='select-row'></td>'+' <td>" + name + "</td><td>" + lastname + "</td><td>" + Vize + "</td><td>" + Final +
            '</td><td><button class="btn btn-info btn-xs btn-edit">Edit</button><button class="btn btn-danger btn-xs btn-delete">Delete</button></td></tr>');
    })

    // Select all checkbox
    $("#select-all").click(function () {
        var isSelected = $(this).is(":checked");
        if (isSelected) {
            $(".table tbody tr").each(function () {
                $(this).find('input[type="checkbox"]').prop('checked', true);
            })
        } else {
            $(".table tbody tr").each(function () {
                $(this).find('input[type="checkbox"]').prop('checked', false);
            })
        }
    });

    $("body").on("click", ".btn-cancel", function () {
        var name = $(this).parents("tr").attr('data-name');
        var lastName = $(this).parents("tr").attr('data-lastName');
        var vize = $(this).parents("tr").attr('data-vize');
        var final = $(this).parents("tr").attr('data-final');

        $(this).parents("tr").find("td:eq(1)").text(name);
        $(this).parents("tr").find("td:eq(2)").text(lastName);
        $(this).parents("tr").find("td:eq(3)").text(vize);
        $(this).parents("tr").find("td:eq(4)").text(final);

        $(this).parents("tr").find(".btn-edit").show();
        $(this).parents("tr").find(".btn-update").remove();
        $(this).parents("tr").find(".btn-cancel").remove();
    });

    $("body").on("click", ".btn-delete", function () {
        var Id = $(this).parents("tr").attr('data-Id');


        const endPoint = `https://localhost:7236/api/Student/${Id}`;

        $.ajax({
            url: endPoint,
            type: "DELETE",
            success: function (result) {
                console.log(result);
            },
            contentType: "application/json",
            dataType: 'json',
            error: function (error) {
                console.log(`Error ${error}`);
            }
        });




        $(this).parents("tr").remove();
    });
})