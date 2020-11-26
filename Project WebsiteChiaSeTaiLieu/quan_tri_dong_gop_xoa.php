<?php 
	$ket_noi = mysqli_connect("remotemysql.com:3306", "MFjxl5C769", "4yl0CnAF1W", "MFjxl5C769");

	$id_dong_gop=$_GET["id"];

	$sql = "
		DELETE
		FROM dong_gop
		WHERE id_dong_gop='".$id_dong_gop."'
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
				window.location.href = './quan_tri_dong_gop.php'
			</script>
		";
;?>