<?php 
	$ket_noi = mysqli_connect("remotemysql.com:3306", "MFjxl5C769", "4yl0CnAF1W", "MFjxl5C769");
	$ngay_dang = date("Y-m-d");
	$ten_tai_lieu = $_POST["txtTenTaiLieu"];
	$chu_de = $_POST["txtChuDe"];
	$dinh_dang = $_POST["txtDinhDang"];
	$so_trang = $_POST["txtSoTrang"];
	$mo_ta = $_POST["txtMoTa"];
	$uploads_img = './images';
	$uploads_file = './pdf';
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
		INSERT INTO `tai_lieu` (`tieu_de`, `id_chu_de`, `ma_dinh_dang`, `mo_ta`, `file`, `id_nguoi_dung`, `nguoi_chia_se`, `ngay_dang`, `so_trang`, `anh_tai_lieu`) 
		VALUES ('".$ten_tai_lieu."', ".$chu_de.", '".$dinh_dang."', '".$mo_ta."', '".$file_tai_lieu."', 1, 'Anonymous', '".$ngay_dang."', ".$so_trang.", '".$file_anh."'); 
	";
	//echo $sql;exit();
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
				window.location.href = './quan_tri_tai_lieu.php?t=ngay_dang'
			</script>
		";
;?>