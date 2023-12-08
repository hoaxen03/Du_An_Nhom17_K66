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

//$(".sv_edit").click(function () {
//    var $row = $(this).closest("tr");    // Find the row
//    var $tds = $row.find("td");
//    $.each($tds, function () {
//        console.log($(this).text());
//    });
//});


async function viedata(msv) {
    const options = {
        method: "GET",
        body: JSON.stringify(msv)
    }
    const response = await fetch(url + "/" + msv.trim(), options);
    var data = await response.json();
    console.log(data);

    alert(data.hodem + data.ten);
}

async function deldata(msv) {
    const options = {
        method: "DELETE",
        body: JSON.stringify(msv)
    }
    const response = await fetch(url+"/"+msv, options);
    var data = await response.json();
    test = data;
    console.log(data);
    $('#addSinhVien').modal('hide');
    clear_all();
    show_table(data);
}



var btn_action = `
    <div>
        <button type="button" class="btn btn-success btnXem" onclick="view_sinhvien()">Xem</button>
        <button type="button" class="btn btn-info btnSua" onclick="edit_sinhvien()">Sửa</button>
        <button type="button" class="btn btn-danger btnXoa" data-toggle="modal" onclick="dele_sinhvien()">Xóa</button>
    </div >`
//function show_table(arrs) {
//    let tb_row = `<tr class="text-center font-italic font-weight-light">
//        <td>(1)</td>
//        <td>(2)</td>
//        <td>(3)</td>
//        <td>(4)</td>
//        <td>(5)</td>
//        <td>(6)</td>
//        <td>(7)</td>
//        <td>(8)</td>
//        </tr>`;

    arrs.forEach(function show(p) {
        tb_row += `<tr class="httt_row">
        <td>${p.msv} </td>
        <td>${p.lop}</td>
        <td>${p.khoavien}</td>
        <td>${p.cccd}</td>
        <td>${p.hodem} ${p.ten}</td>
        <td class="text-center">${p.tuoi}</td>
        <td>${p.tien}</td>
        <td class="text-center">${btn_action}</td>
        </tr>`;
    });

    // Setting innerHTML as tab variable
//    document.getElementById("dsSinhVien").innerHTML = tb_row;

function clear_all() {
    document.querySelectorAll(".httt_row").forEach(el => el.remove());
}

function refresh_all() {
    show_table(test);
}

function save_sinhvien() {
    //var msv = document.getElementById("msv").value;
    //var lop = document.getElementById("lop").value;
    //var khoavien = document.getElementById("khoavien").value;
    //var cccd = document.getElementById("cccd").value;
    //var hodem = document.getElementById("hodem").value;
    //var ten = document.getElementById("ten").value;
    //var tuoi = document.getElementById("tuoi").value;

    var my_msv = $("#msv").val();
    var my_lop = $("#lop").val();
    var my_khoavien = $("#khoavien").val();
    var my_cccd = $("#cccd").val();
    var my_hodem = $("#hodem").val();
    var my_ten = $("#ten").val();
    var my_tuoi = $("#tuoi").val();
    var my_tien = $("#tien").val();

    var data = {
        "msv": my_msv,
        "lop": my_lop,
        "khoavien": my_khoavien,
        "cccd": my_cccd,
        "hodem": my_hodem,
        "ten": my_ten,
        "bietdanh": "",
        "email": "",
        "dienthoai": "",
        "tuoi": my_tuoi,
        "tien": my_tien
    }

    adddata(data);
}

function view_sinhvien() {
    $(".btnXem").on('click', function () {
        var currentRow = $(this).closest("tr");
        var col1 = currentRow.find("td:eq(0)").html();
        viedata(col1);
    });
}

function dele_sinhvien() {
    $(".btnXoa").on('click', function () {
        var currentRow = $(this).closest("tr");
        var col1 = currentRow.find("td:eq(0)").html();
        //var col2 = currentRow.find("td:eq(1)").html();

        $('#delSinhVien').modal('show');
        $('#del_sv').on("click", function () {
            $('#delSinhVien').modal('hide');
            deldata(col1);
        });       
    });
}
