const url = "http://localhost:63223/api/Student";
let test;

// Cach 1:
async function getapi(url) {
    const tmp = await fetch(url,);
    var data = await tmp.json();
    test = data;
    console.log(data);
    show_table(data);
}
getapi(url);


// Cach 2:
//async function getapi(url) {
//    try {
//        const response = await fetch(url);

//        if (!response.ok) {
//            throw new Error(`Error! status: ${response.status}`);
//            console.log(response.status);
//        }

//        const result = await response.json();
//        return result;
//    } catch (err) {
//        console.log(err);
//    }
//}

//getapi();

function show_table(arrs) {
    let tb_row;
    //tb_row = `<tr>
    //    <td>(1)</td>
    //    <td>(2)</td>
    //    <td>(3)</td>
    //    <td>(4)</td>
    //    <td>(5)</td>
    //    <td>(6)</td>
    //    </tr>`;

    arrs.forEach(function show(p) {
        tb_row += `<tr class="httt_row");>
        <td>${p.msv} </td>
        <td>${p.lop}</td>
        <td>${p.khoavien}</td>
        <td>${p.cccd}</td>
        <td>${p.hodem} ${p.ten}</td>
        <td>${p.tuoi}</td>
        </tr>`;
    });

    // Setting innerHTML as tab variable
    document.getElementById("dsSinhVien").innerHTML = tb_row;
}

function clear_all() {
    document.querySelectorAll(".httt_row").forEach(el => el.remove());
}

function show_all() {
    show_table(test);
}

