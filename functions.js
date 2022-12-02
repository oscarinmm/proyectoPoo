$(document).ready(function () {  
    $.ajax({  
        type: "GET",  
        url: "http://oscarmoreno2022-001-site1.htempurl.com/api/v1/ERA/listar",    
        dataType: "json", 
        success: function (data) {  
              $.each(data, function(i,item){
                    var row = "<tr>"+
                    "<td>" + item.codigo + "</td>" + 
                    "<td>" + item.marca + "</td>" +
                    "<td>" + item.estado + "</td>" +
                    "<td>" + item.tipo + "</td>" +
                    "<td>" + item.pertenece + "</td>" +
                    "</tr>";						 
                   $("#tabla>tbody").append(row);
               });
        }, //End of AJAX Success function  
    });         
}); 