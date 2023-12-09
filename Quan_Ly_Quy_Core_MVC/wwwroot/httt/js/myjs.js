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


function adddata(data) {
    const options = {
        method: "POST",
        headers: {
            "Content-Type": "application/json; charset=utf-8",
            "Access-Control-Allow-Origin": '*',
            "Access-Control-Allow-Methods": 'PUT,GET,HEAD,POST,DELETE,OPTIONS'
        },
        body: JSON.stringify(data)
    }
    fetch(url, options)
        .then(response => response.json())
        .then(data => {
            test = data;
            console.log(data);
            $('#addSinhVien').modal('hide');
            clear_all();
            show_table(data);
        })
        .catch(error => {
            console.error('Error:', error);
        });
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
    const response = await fetch(url + "/" + msv, options);
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
function show_table(arrs) {
    let tb_row = `<tr class="text-center font-italic font-weight-light">
        `;

    arrs.forEach(function show(p) {
        tb_row += `<tr class="httt_row">
        <td>${p.msv} </td>
        <td>${p.lop}</td>
        <td>${p.khoavien}</td>
        <td>${p.cccd}</td>
        <td>${p.hodem} ${p.ten}</td>
        <td class="text-center">${p.tuoi}</td>
        <td class="text-center">${p.tien}</td>
        <td class="text-center">${btn_action}</td>
        </tr>`;
    });

    // Setting innerHTML as tab variable
    document.getElementById("dsSinhVien").innerHTML =tb_row;
}

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
        "tien": my_tien,
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

function dele_sinhvien()
{
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
/*
function getTotalDues(url) { // Khai báo một hàm với tham số là url của api
    let xhr = new XMLHttpRequest(); // Tạo một đối tượng XMLHttpRequest để gửi và nhận dữ liệu từ api
    xhr.open("GET", url, true); // Mở một kết nối GET đến url
    xhr.onload = function () { // Đăng ký một hàm xử lý khi nhận được phản hồi từ api
        if (this.status == 200) { // Kiểm tra nếu trạng thái của phản hồi là 200 (thành công)
            let Student = JSON.parse(this.responseText); // Chuyển đổi chuỗi JSON thành đối tượng JavaScript
            let total = 0; // Khai báo một biến để lưu trữ tổng số tiền
            for (let student of Student) { // Duyệt qua các phần tử của mảng students
                total += student.tien; // Cộng dồn giá trị của trường money của mỗi sinh viên vào biến total
            }
            console.log(total); // In ra tổng số tiền của quỹ lớp
        } else { // Nếu trạng thái của phản hồi không phải là 200
            console.error("Lỗi: " + this.status); // In ra lỗi
        }
    };
    xhr.send(); // Gửi yêu cầu đến api
}

getTotalDues("http://localhost:5077/api/Student"); // Gọi hàm với url của api
*/
//tính tổng số dư quỹ lớp
//const response = await fetch(url + "/" + tien.trim(), options);
//var data = await response.json();
//console.log(data);
// Lấy dữ liệu từ API
async function totalMoney()
{
    const response = await fetch("http://localhost:5077/api/Student");
    const data = await response.json();

    // Tạo biến tổng số dư
    let totalMoney = 0;

    // Duyệt qua danh sách sinh viên
    for (const student of data) {
        // Thêm số tiền của sinh viên vào tổng số dư
        totalMoney += student.tien;
    }

    // Hiển thị tổng số dư trên trang web
    document.querySelector("#classMoney").innerHTML = totalMoney;
}