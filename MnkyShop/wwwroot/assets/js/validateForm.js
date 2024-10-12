function validate($event) {
    if (document.getElementById('IdSp').selectedIndex === 0) {
        alert('Bạn chưa chọn sản phẩm!');
        $event.preventDefault();
        return false;
    }

    if (document.getElementById('IdNsx').selectedIndex === 0) {
        alert('Bạn chưa chọn nhà sản xuất!');
        $event.preventDefault();
        return false;
    }

    if (document.getElementById('IdMauSac').selectedIndex === 0) {
        alert('Bạn chưa chọn màu sắc!');
        $event.preventDefault();
        return false;
    }
    if (document.getElementById('IdDongSp').selectedIndex === 0) {
        alert('Bạn chưa chọn dòng sản phẩm!');
        $event.preventDefault();
        return false;
    }
    return true;
}

function myFunction() {
    var input, table, tr, td, txtValue;
    input = document.getElementById("myInput").value.toUpperCase();
    table = document.getElementById("myTable");
    tr = table.getElementsByTagName("tr");

    for (var i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[1];
        if (td) {
            txtValue = td.textContent || td.innerText;
            if (txtValue.toUpperCase().indexOf(input) > -1) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
}