const url1 = "http://localhost:5077/api/ThuChi"; // Thay đổi URL API phù hợp
const total = window.globalThis.total;

// Hàm lấy dữ liệu thu chi
async function getThuChi(url1) {
    const options = {
        method: "GET",
        headers: {
            "Content-Type": "application/json; charset=utf-8",
            "Access-Control-Allow-Origin": "*",
            "Access-Control-Allow-Methods": "PUT,GET,POST,DELETE,OPTIONS",
            "Access-Control-Allow-Headers": "Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With, Origin, X-Auth-Token"
        }
    }
    const response = await fetch(url1,options);
    const data1 = await response.json();
    return data1;
}
async function getThuChiById(id) {
    const options = {
        method: "GET",
    };
    const response = await fetch(url1 + "/" + id, options);
    const data1 = await response.json();
    return data1;
}

// Kiểm tra giá trị của biến total
if (total > 1000000) {
    console.log("Số dư quỹ lớp học lớn hơn 1 triệu đồng");
} else {
    console.log("Số dư quỹ lớp học nhỏ hơn hoặc bằng 1 triệu đồng");
}

// Hàm tính tổng số tiền quỹ
function calculateTotal(data) {
    return total;
}

// Hàm hiển thị dữ liệu thu chi
function showThuChi(data1) {
    let tableContent = "";
    data1.forEach((item) => {
        tableContent += `<tr>
      <td>${item.id}</td>
      <td>${item.ngayChi}</td>
      <td>${item.Loai}</td>
      <td>${item.soTien.toLocaleString("vi-VN")}</td>
      <td>${item.tenKhoanChi}</td>
      <td>
      <button onclick="showThuChiDetail(${item.id})">Xem</button>
      <button onclick="editThuChi(${item.id})">Sửa</button>
      <button onclick="deleteThuChi(${item.id})">Xóa</button>
    </td>
    </tr>`;
    });
    document.getElementById("tableBody").innerHTML = tableContent;
    document.getElementById("total").textContent =
        total.toLocaleString("vi-VN") + " đ";
}

// Hàm thêm mới dữ liệu thu chi
async function addThuChi(data1) {
    const options = {
        method: "POST",
        headers: {
            "Content-Type": "application/json; charset=utf-8",
        },
        body: JSON.stringify(data1),
    };
    try {
        const response = await fetch(url1, options);
        const result = await response.json();
        if (result.success) {
            console.log("Thêm dữ liệu thành công");
            // Cập nhật dữ liệu
            const updatedData = await getThuChi(url1);
            total = calculateTotal(updatedData);
            showThuChi(updatedData);
        } else {
            console.error("Thêm dữ liệu thất bại");
        }
    } catch (error) {
        console.error(error);
    }
}

// Hàm xóa dữ liệu thu chi
async function deleteThuChi(id) {
    const options = {
        method: "DELETE",
    };
    try {
        const response = await fetch(url1 + "/" + id, options);
        const result = await response.json();
        if (result.success) {
            console.log("Xóa dữ liệu thành công");
            // Cập nhật dữ liệu
            const updatedData = await getThuChi(url);
            total = calculateTotal(updatedData);
            showThuChi(updatedData);
        } else {
            console.error("Xóa dữ liệu thất bại");
        }
    } catch (error) {
        console.error(error);
    }
}

// Lấy dữ liệu ban đầu
getThuChi(url1).then((data1) => {
    total = calculateTotal(data1);
    showThuChi(data1);
});

// Sự kiện thêm mới dữ liệu
document.getElementById("addThuChiForm").addEventListener("submit", (event) => {
    event.preventDefault();
    const formData = new FormData(event.target);
    const data1 = {
        ngayChi: formData.get("ngayChi"),
        Loai: formData.get("Loai"),
        soTien: parseFloat(formData.get("soTien")),
        tenKhoanChi: formData.get("TenKhoanChi"),
    };
    addThuChi(data1);
});

// Sự kiện xóa dữ liệu
document.getElementById("tableBody").addEventListener("click", (event) => {
    if (event.target.tagName === "BUTTON") {
        const id = event.target.dataset.id;
        deleteThuChi(id);
    }
});
function showThuChiDetail(id) {
    // Lấy thông tin khoản thu chi
    const thuChi = await getThuChiById(id);

    // Tạo modal
    const modal = new bootstrap.Modal(document.getElementById("modal-thu-chi"));

    // Thêm nội dung vào modal
    modal.find(".modal-body").html(`
    <h4>Thông tin khoản thu chi</h4>
    <table>
      <tr>
        <td>ID</td>
        <td>${thuChi.id}</td>
      </tr>
      <tr>
        <td>Ngày chi</td>
        <td>${thuChi.ngayChi}</td>
      </tr>
      <tr>
        <td>Loại</td>
        <td>${thuChi.Loai}</td>
      </tr>
      <tr>
        <td>Số tiền</td>
        <td>${thuChi.soTien.toLocaleString("vi-VN")}</td>
      </tr>
      <tr>
        <td>Tên khoản chi</td>
        <td>${thuChi.tenKhoanChi}</td>
      </tr>
    </table>
  `);

    // Hiển thị modal
    modal.show();
}
async function editThuChi(id) {
    // Lấy thông tin khoản thu chi
    const thuChi = await getThuChiById(id);

    // Tạo form sửa
    const form = document.createElement("form");
    form.action = "/api/thu-chi/edit";
    form.method = "post";

    // Điền thông tin khoản thu chi vào form
    form.appendChild(document.createElement("input"));
    form.appendChild(document.createElement("input"));
    form.appendChild(document.createElement("input"));
    form.appendChild(document.createElement("input"));
    form.appendChild(document.createElement("input"));

    // Hiển thị form
    const modal = new bootstrap.Modal(document.getElementById("modal-thu-chi"));
    modal.find(".modal-body").html(form);
    modal.show();
}
