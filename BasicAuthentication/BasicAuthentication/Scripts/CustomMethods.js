
$(document).ready(function () {
    var ulEmployees = $('#ulEmployees');
    $('#btn').click(function () {
        var gender = $('#txtgender').val();
        var password = $('#txtpass').val();
        $.ajax({
            type: 'get',
            url: 'api/values',
            dataType: 'jsonp',
            headers: {
                'Authorization': 'Basic ' + btoa(gender+':'+ password)
            },
            success: function (data) {
                ulEmployees.empty();
                $.each(data, function (index, value) {
                    ulEmployees.append("<li>" + value.Name + "</li>");
                })
            },
            complete: function (jqXHR) {
                if (jqXHR.status == '401') {
                    ulEmployees.empty();
                    ulEmployees.append("<li>" + jqXHR.status + ":" + jqXHR.statusText + "</li>");
                }
            }
        });
    });
});