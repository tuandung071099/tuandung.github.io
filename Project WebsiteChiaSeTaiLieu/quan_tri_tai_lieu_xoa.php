<?php 
	$ket_noi = mysqli_connect("remotemysql.com:3306", "MFjxl5C769", "4yl0CnAF1W", "MFjxl5C769");

	$id_tai_lieu=$_GET["id"];

	$sql = "
		DELETE
		FROM tai_lieu
		WHERE id_tai_lieu='".$id_tai_lieu."'
	";
	//echo $sql;exit();
	mysqli_query($ket_noi, $sql);


		echo 
		"
			<script type='text/javascript'>
				window.alert('Bạn đã xóa tài liệu thành công.');
			</script>
		";

		echo 
		"
			<script type='text/javascript'>
				window.location.href = './quan_tri_tai_lieu.php?t=ngay_dang'
			</script>
		";
;?>