const url1 = "http://localhost:5077/api/Student";
// let test;
let data;

// Khai báo biến options bên ngoài hàm getdata
const options = {
    method: "GET",
    headers: {
        "Content-Type": "application/json; charset=utf-8",
        "Access-Control-Allow-Origin": "*",
        "Access-Control-Allow-Methods": "PUT,GET,POST,DELETE,OPTIONS",
        "Access-Control-Allow-Headers": "Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With, Origin, X-Auth-Token"
    }
};
let total = 0;
async function getdata(url1) {
    try {
        const response = await fetch(url1, options);
        data = await response.json();
        console.log(data);
        // Tính tổng số tiền của tất cả các sinh viên
        for (const student of data) {
            if (student.tien) { // Kiểm tra thuộc tính tien
                total += student.tien;
            }
        }
        return total;
        // Kiểm tra giá trị của biến total
        if (total > 1000000) {
            console.log("Số dư quỹ lớp học lớn hơn 1 triệu đồng");
        } else {
            console.log("Số dư quỹ lớp học nhỏ hơn hoặc bằng 1 triệu đồng");
        }
    } catch (error) {
        console.error(error);
    }
}
getdata(url1);
