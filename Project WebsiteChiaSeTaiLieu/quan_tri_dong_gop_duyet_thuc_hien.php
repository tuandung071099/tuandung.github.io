<?php 
	$ket_noi = mysqli_connect("remotemysql.com:3306", "MFjxl5C769", "4yl0CnAF1W", "MFjxl5C769");
	$id_dong_gop = $_POST["txtID"];
	$ngay_dang = date("Y-m-d");
	$nguoi_chia_se = $_POST["txtNguoiChiaSe"];
	$ten_tai_lieu = $_POST["txtTenTaiLieu"];
	$chu_de = $_POST["txtChuDe"];
	$dinh_dang = $_POST["txtDinhDang"];
	$so_trang = $_POST["txtSoTrang"];
	$mo_ta = $_POST["txtMoTa"];
	$file_anh =  $_POST["txtFileAnh"];
	$file_tai_lieu =  $_POST["txtFileTaiLieu"];
	if($nguoi_chia_se == "")
	{$nguoi_chia_se =null;}
	//echo $file_tai_lieu;exit();
	$sql_duyet = "
		INSERT INTO `tai_lieu` (`tieu_de`, `id_chu_de`, `ma_dinh_dang`, `mo_ta`, `file`, `id_nguoi_dung`, `nguoi_chia_se`, `ngay_dang`, `so_trang`, `anh_tai_lieu`) 
		VALUES ('".$ten_tai_lieu."', ".$chu_de.", '".$dinh_dang."', '".$mo_ta."', '".$file_tai_lieu."', 1, '".$nguoi_chia_se."', '".$ngay_dang."', ".$so_trang.", '".$file_anh."'); 
	";
	$sql_xoa = "
		DELETE
		FROM dong_gop
		WHERE id_dong_gop='".$id_dong_gop."'
	";
	mysqli_query($ket_noi, $sql_duyet);
	mysqli_query($ket_noi, $sql_xoa);

		echo 
		"
			<script type='text/javascript'>
				window.alert('Bạn đã duyệt tài liệu thành công.');
			</script>
		";

		echo 
		"
			<script type='text/javascript'>
				window.location.href = './quan_tri_tai_lieu.php?t=ngay_dang'
			</script>
		";
;?>