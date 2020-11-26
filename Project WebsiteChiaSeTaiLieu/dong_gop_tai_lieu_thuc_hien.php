<?php 
$ket_noi = mysqli_connect("remotemysql.com:3306", "MFjxl5C769", "4yl0CnAF1W", "MFjxl5C769");
$ngay_dang = date("Y-m-d");
$chu_de = $_POST["txtChuDe"];
$ten_tai_lieu = $_POST["txtTenTaiLieu"];
if($ten_tai_lieu == "") {
	$ten_tai_lieu = null;
}
$dinh_dang = $_POST["txtDinhDang"];
$so_trang = $_POST["txtSoTrang"];
if($so_trang == "") {
	$so_trang = 0;
}
$nguoi_chia_se = $_POST["txtNguoiChiaSe"];
if($nguoi_chia_se == "") {
	$nguoi_chia_se = null;
}
$mo_ta = $_POST["txtMoTa"];
if($mo_ta == "") {
	$mo_ta = null;
}
$uploads_img = './dong_gop_img';
$uploads_file = './dong_gop_doc';
$file_anh = basename($_FILES["txtFileAnh"]["name"]);
$file_anh_tam = $_FILES['txtFileAnh']["tmp_name"];
$result = move_uploaded_file($file_anh_tam,"$uploads_img/$file_anh");
if(!$result) {
	$file_anh = NULL;
}
$file_tai_lieu = basename($_FILES["txtFileTaiLieu"]["name"]);
$file_tai_lieu_tam = $_FILES['txtFileTaiLieu']["tmp_name"];
$result = move_uploaded_file($file_tai_lieu_tam,"$uploads_file/$file_tai_lieu");
if(!$result) {
	$file_tai_lieu = NULL;
}
$sql = "
INSERT INTO `dong_gop`(`tieu_de`, `dinh_dang`, `so_trang`, `id_chu_de`, `nguoi_chia_se`, `file`, `anh_tai_lieu`, `ngay_chia_se`, `mo_ta`) 
VALUES ('".$ten_tai_lieu."','".$dinh_dang."','".$so_trang."','".$chu_de."','".$nguoi_chia_se."','".$file_tai_lieu."','".$file_anh."','".$ngay_dang."','".$mo_ta."')
";

mysqli_query($ket_noi, $sql);
echo 
"
<script type='text/javascript'>
window.alert('Bạn đã thêm mới tài liệu thành công.');
</script>
";

echo 
"
<script type='text/javascript'>
window.location.href = './index.php?t=ngay_dang'
</script>
";
;?>