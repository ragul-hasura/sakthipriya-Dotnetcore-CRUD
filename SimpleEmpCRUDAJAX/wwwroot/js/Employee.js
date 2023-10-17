

//Load Data in Table when documents is ready
$(document).ready(function () {
    loadData();
});

    function loadData() {
        $.ajax({
            url: "/Home/TestEmployeeDetails",
            type: "GET",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                var html = '';
                $.each(result, function (key, item) {
                    html += '<tr>';
                    html += '<td>' + item.empId + '</td>';
                    html += '<td>' + item.name + '</td>';
                    html += '<td>' + item.age + '</td>';
                    html += '<td>' + item.state + '</td>';
                    html += '<td>' + item.country + '</td>';
                    html += '<td>' + item.salary + '</td>';
                    html += '<td><a href="#" onclick="return getbyID(' + item.empId + ')">Edit</a> | <a href="#" onclick="Delete(' + item.empId + ')">Delete</a></td>';
                    html += '</tr>';
                });
                $('.tbody').html(html);
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    };
function Add() {
    
        var res = validate();
        if (res == false) {
            return false;
        }
        var empObj = {
            Age: $('#Age').val(),
            Country: $('#Country').val(),
            EmpId: $('#EmpID').val(),
            Name: $('#Name').val(),
            Salary: $('#Salary').val(),
            State: $('#State').val(),
        };
        $.ajax({
            url: "/Home/Add",
            data: JSON.stringify(empObj),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                loadData();
                $('#myModal').modal('hide');
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
}

    function getbyID(EmpID) {
      
        $('#Name').css('border-color', 'lightgrey');
        $('#Age').css('border-color', 'lightgrey');
        $('#State').css('border-color', 'lightgrey');
        $('#Country').css('border-color', 'lightgrey');
        $('#Salary').css('border-color', 'lightgrey');
        $.ajax({
            url: "/Home/getbyID/" + EmpID,
            typr: "GET",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
               
                $('#EmpID').val(result[0].empId);
                $('#Name').val(result[0].name);
                $('#Age').val(result[0].age);
                $('#State').val(result[0].state);
                $('#Country').val(result[0].country);
                $('#Salary').val(result[0].salary);

                $('#myModal').modal('show');
                $('#btnUpdate').show();
                $('#btnAdd').hide();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
        return false;
}
    function Update() 
    {
        
        var res = validate();
        if (res == false) {
            return false;
        }
        var empObj = {
            Age: $('#Age').val(),
            Country: $('#Country').val(),
            EmpId: $('#EmpID').val(),
            Name: $('#Name').val(),
            Salary: $('#Salary').val(),
            State: $('#State').val(),
        };
        $.ajax({
            url: "/Home/Update",
            data: JSON.stringify(empObj),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                loadData();
                $('#myModal').modal('hide');
                $('#EmployeeID').val("");
                $('#Name').val("");
                $('#Age').val("");
                $('#State').val("");
                $('#Country').val("");
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    } 
function Delete(EmpId) {
    
        var ans = confirm("Are you sure you want to delete this Record?");
        if (ans) {
            $.ajax({
                url: "/Home/Delete/" + EmpId,
                type: "POST",
                contentType: "application/json;charset=UTF-8",
                dataType: "json",
                success: function (result) {
                    loadData();
                },
                error: function (errormessage) {
                    alert(errormessage.responseText);
                }
            });
        }

}
function closeBtn() {
   
    $('#myModal').modal('hide');
}
    function clearTextBox()
    {
       
        $('#EmployeeID').val("");
        $('#Name').val("");
        $('#Age').val("");
        $('#State').val("");
        $('#Country').val("");
        $('#btnUpdate').hide();
        $('#myModal').modal('show');
        $('#btnAdd').show();
        $('#Name').css('border-color', 'lightgrey');
        $('#Age').css('border-color', 'lightgrey');
        $('#State').css('border-color', 'lightgrey');
        $('#Country').css('border-color', 'lightgrey');
    }

//Valdidation using jquery  
    function validate()
    {
        var isValid = true;
        if ($('#Name').val().trim() == "") {
            $('#Name').css('border-color', 'Red');
            isValid = false;
        }
        else {
            $('#Name').css('border-color', 'lightgrey');
        }
        if ($('#Age').val().trim() == "") {
            $('#Age').css('border-color', 'Red');
            isValid = false;
        }
        else {
            $('#Age').css('border-color', 'lightgrey');
        }
        if ($('#State').val().trim() == "") {
            $('#State').css('border-color', 'Red');
            isValid = false;
        }
        else {
            $('#State').css('border-color', 'lightgrey');
        }
        if ($('#Country').val().trim() == "") {
            $('#Country').css('border-color', 'Red');
            isValid = false;
        }
        else {
            $('#Country').css('border-color', 'lightgrey');
        }
        return isValid;
    } 
