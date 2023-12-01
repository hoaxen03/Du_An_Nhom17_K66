const url = "http://localhost:5077/api/Student";
let test;

async function getdata(url) {
    const options = {
        method: 'GET',
        headers: {
            "Content-Type": "application/json; charset=utf-8",
            "Access-Control-Allow-Origin": "*",
            "Access-Control-Allow-Methods": "PUT,GET,POST,DELETE,OPTIONS",
            "Access-Control-Allow-Headers": "Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With, Origin, X-Auth-Token"
        }
    }
    const response = await fetch(url, options);
    var data = await response.json();
    test = data;
    console.log(data);
    show_table(data);
}
getdata(url);


async function adddata(data) {
    const options = {
        method: "POST",
        headers: {
            "Content-Type": "application/json; charset=utf-8",
            "Access-Control-Allow-Origin": '*',
            "Access-Control-Allow-Methods": 'PUT,GET,HEAD,POST,DELETE,OPTIONS'
        },
        body: JSON.stringify(data)
    }
    const response = await fetch(url, options);
    var data = await response.json();
    test = data;
    console.log(data);
    $('#addSinhVien').modal('hide');
    clear_all();
    show_table(data);
}
// Che đi 
//".sv_edit").click(function () {
//  var $row = $(this).closest("tr");    // Find the row
//  var $tds = $row.find("td");
//  $.each($tds, function () {
//      console.log($(this).text());
//  });
});
//