<?php 
	$ket_noi = mysqli_connect("remotemysql.com:3306", "MFjxl5C769", "4yl0CnAF1W", "MFjxl5C769");

	$id_chu_de = $_POST["txtID"];
	$ten_chu_de = $_POST["txtTenCD"];
	$phan_loai = $_POST["txtPhanLoai"];

		$sql = "
			UPDATE `chu_de` 
			SET
				`ten_chu_de` = '".$ten_chu_de."',
				`id_loai_tai_lieu` = ".$phan_loai."
			WHERE `id_chu_de` = ".$id_chu_de."
		";
	//echo $sql;exit();
	mysqli_query($ket_noi, $sql);


		echo 
		"
			<script type='text/javascript'>
				window.alert('Bạn đã cập nhật chủ đề thành công.');
			</script>
		";

		echo 
		"
			<script type='text/javascript'>
				window.location.href = './quan_tri_chu_de.php'
			</script>
		";
;?>