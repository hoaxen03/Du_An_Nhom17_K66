const url = "http://localhost:5077/api/ThuChi"; // Thay đổi URL API phù hợp
import { total } from "./QuanLyQuy";
if (typeof total === "undefined") {
    console.error("Không thể lấy được biến total từ QuanLyQuy.js");
    return;
}
// Hàm lấy dữ liệu thu chi
async function getThuChi(url)
{
    const options = {
        method: "GET",
        headers: {
            "Content-Type": "application/json; charset=utf-8", "Access-Control-Allow-Origin": '*',
            "Access-Control-Allow-Methods": 'PUT,GET,HEAD,POST,DELETE,OPTIONS',
        },
    };

    const response = await fetch(url, options);
    const data = await response.json();
    total = calculateTotal(data);
    return data;
}
getThuChi(url, total);

// Hàm tính tổng số tiền quỹ
function calculateTotal(data) {
    total = 0;
    data.forEach((item) => {
        if (item.loai === "Thu") {
            total += item.soTien;
        } else if (item.loai === "Chi") {
            total -= item.soTien;
        }
    });
    return total;
    console.log(total);
}

// Hàm hiển thị dữ liệu thu chi
function showThuChi(data) {
    let tableContent = "";
    data.forEach((item) => {
        tableContent += `<tr>
      <td>${item.id}</td>
      <td>${item.ngayChi}</td>
      <td>${item.loai}</td>
      <td>${item.soTien.toLocaleString("vi-VN")}</td>
      <td>${item.tenKhoanChi}</td>
      <td>
        <button type="button" data-id="${item.id}" class="btn-view btn-success">Xem</button>
        <button type="button" data-id="${item.id}" class="btn-edit btn-info">Sửa</button>
        <button type="button" data-id="${item.id}" class="btn-delete btn-danger">Xóa</button>
      </td>
    </tr>`;
    });
    document.getElementById("tableBody").innerHTML = tableContent;
    document.getElementById("total").textContent =
        total.toLocaleString("vi-VN") + " đ";
}

// Hàm thêm mới dữ liệu thu chi
async function addThuChi(data) {
    const options = {
        method: "POST",
        headers: {
            "Content-Type": "application/json; charset=utf-8",
        },
        body: JSON.stringify(data),
    };
    try {
        const response = await fetch(url, options);
        const result = await response.json();
        if (result.success) {
            console.log("Thêm dữ liệu thành công");
            // Cập nhật dữ liệu
            const updatedData = await getThuChi(url);
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
        const response = await fetch(url + "/" + id, options);
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
getThuChi(url).then((data) => {
    total = calculateTotal(data);
    showThuChi(data);
});

// Sự kiện thêm mới dữ liệu
document.getElementById("addThuChiForm").addEventListener("submit", (event) => {
    event.preventDefault();
    const formData = new FormData(event.target);
    const data = {
        ngayChi: formData.get("ngayChi"),
        loai: formData.get("loai"),
        soTien: parseFloat(formData.get("soTien")),
        tenKhoanChi: formData.get("tenKhoanChi"),
    };
    addThuChi(data);
});

// Sự kiện xóa dữ liệu
document.getElementById("tableBody").addEventListener("click", (event) => {
    if (event.target.tagName === "BUTTON") {
        const id = event.target.dataset.id;
        deleteThuChi(id);
    }
});
document.getElementById("tableBody").addEventListener("click", (event) => {
    if (event.target.classList.contains("btn-view")) {
        const id = event.target.dataset.id;
        // Hiển thị chi tiết khoản thu chi
        // 1. Tạo phần tử HTML để hiển thị chi tiết
        const modalElement = document.createElement("div");
        modalElement.classList.add("modal");
        modalElement.innerHTML = `
    <div class="modal-content">
      <h2>Khoản thu chi ID: ${id}</h2>
      <p>Ngày: ${data.find(item => item.id === id).ngayChi}</p>
      <p>Loại: ${data.find(item => item.id === id).loai}</p>
      <p>Số tiền: ${data.find(item => item.id === id).soTien.toLocaleString("vi-VN")}</p>
      <p>Nội dung: ${data.find(item => item.id === id).tenKhoanChi}</p>
      <button class="modal-close">Đóng</button>
    </div>
  `;
        document.body.appendChild(modalElement);

        // 2. Thêm sự kiện click cho nút đóng modal
        modalElement.querySelector(".modal-close").addEventListener("click", () => {
            document.body.removeChild(modalElement);
        });
    } else if (event.target.classList.contains("btn-edit")) {
        const id = event.target.dataset.id;
        // Mở form edit với dữ liệu hiện tại
        const item = data.find(item => item.id === id);

        // 2. Mở form edit với dữ liệu hiện tại
        document.getElementById("editForm").style.display = "block";
        document.getElementById("editForm").elements["ngayChi"].value = item.ngayChi;
        document.getElementById("editForm").elements["loai"].value = item.loai;
        document.getElementById("editForm").elements["soTien"].value = item.soTien;
        document.getElementById("editForm").elements["tenKhoanChi"].value = item.tenKhoanChi;
        // 3. Xử lý logic submit form edit (cập nhật dữ liệu)
        document.getElementById("editForm").addEventListener("submit", (event) => {
            // ...
        });
    } else if (event.target.classList.contains("btn-delete")) {
        const id = event.target.dataset.id;
        deleteThuChi(id);
    }
});