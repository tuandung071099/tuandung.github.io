<?php
$ket_noi = mysqli_connect("remotemysql.com:3306", "MFjxl5C769", "4yl0CnAF1W", "MFjxl5C769");

$id_tai_lieu = $_POST["txtID"];
$ten_tai_lieu = $_POST["txtTenTaiLieu"];
$chu_de = $_POST["txtChuDe"];
$dinh_dang = $_POST["txtDinhDang"];
$so_trang = $_POST["txtSoTrang"];
$mo_ta = $_POST["txtMoTa"];
$uploads_img = './images';
$uploads_file = './pdf';
$file_anh = basename($_FILES["txtFileAnh"]["name"]);
$file_anh_tam = $_FILES['txtFileAnh']["tmp_name"];
$result = move_uploaded_file($file_anh_tam, "$uploads_img/$file_anh");
if (!$result) {
	$file_anh = NULL;
}
$file_tai_lieu = basename($_FILES["txtFileTaiLieu"]["name"]);
$file_tai_lieu_tam = $_FILES['txtFileTaiLieu']["tmp_name"];
$result = move_uploaded_file($file_tai_lieu_tam, "$uploads_file/$file_tai_lieu");
if (!$result) {
	$file_tai_lieu = NULL;
}
if ($file_tai_lieu == NULL && $file_anh == NULL) {
	$sql = "
			UPDATE `tai_lieu` 
			SET
				`tieu_de` = '" . $ten_tai_lieu . "',
				`id_chu_de` = " . $chu_de . ",
				`ma_dinh_dang` = '" . $dinh_dang . "',
				`mo_ta` = '" . $mo_ta . "',
				`so_trang` = " . $so_trang . "
			WHERE `id_tai_lieu` = " . $id_tai_lieu . "
		";
} else if ($file_tai_lieu == NULL && $file_anh != NULL) {
	$sql = "
			UPDATE `tai_lieu` 
			SET
				`tieu_de` = '" . $ten_tai_lieu . "',
				`id_chu_de` = " . $chu_de . ",
				`ma_dinh_dang` = '" . $dinh_dang . "',
				`mo_ta` = '" . $mo_ta . "',
				`so_trang` = " . $so_trang . ",
				`anh_tai_lieu` = '" . $file_anh . "'
			WHERE `id_tai_lieu` = " . $id_tai_lieu . "
		";
} else if ($file_tai_lieu != NULL && $file_anh == NULL) {
	$sql = "
			UPDATE `tai_lieu` 
			SET
				`tieu_de` = '" . $ten_tai_lieu . "',
				`id_chu_de` = " . $chu_de . ",
				`ma_dinh_dang` = '" . $dinh_dang . "',
				`mo_ta` = '" . $mo_ta . "',
				`file` = " . $file_tai_lieu . ",
				`so_trang` = " . $so_trang . "
			WHERE `id_tai_lieu` = " . $id_tai_lieu . "
		";
} else {
	$sql = "
			UPDATE `tai_lieu` 
			SET
				`tieu_de` = '" . $ten_tai_lieu . "',
				`id_chu_de` = " . $chu_de . ",
				`ma_dinh_dang` = '" . $dinh_dang . "',
				`mo_ta` = '" . $mo_ta . "',
				`file` = " . $file_tai_lieu . ",
				`so_trang` = " . $so_trang . ",
				`anh_tai_lieu` = '" . $file_anh . "'
			WHERE `id_tai_lieu` = " . $id_tai_lieu . "
		";
}
mysqli_query($ket_noi, $sql);


echo
	"
			<script type='text/javascript'>
				window.alert('Bạn đã cập nhật tài liệu thành công.');
			</script>
		";

echo
	"
			<script type='text/javascript'>
				window.location.href = './quan_tri_tai_lieu.php?t=ngay_dang'
			</script>
		";;
