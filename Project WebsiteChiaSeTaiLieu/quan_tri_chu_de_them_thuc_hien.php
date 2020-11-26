<?php 
	$ket_noi = mysqli_connect("remotemysql.com:3306", "MFjxl5C769", "4yl0CnAF1W", "MFjxl5C769");

	$ten_chu_de = $_POST["txtTenCD"];
	$phan_loai = $_POST["txtPhanLoai"];
	//echo $phan_loai;exit();

	$sql = "
		INSERT INTO `chu_de` (`ten_chu_de`, `id_loai_tai_lieu`) 
		VALUES ('".$ten_chu_de."', ".$phan_loai."); 
	";

	//echo $sql;exit();

	mysqli_query($ket_noi, $sql);


		echo 
		"
			<script type='text/javascript'>
				window.alert('Bạn đã thêm mới chủ đề thành công.');
			</script>
		";

		echo 
		"
			<script type='text/javascript'>
				window.location.href = './quan_tri_chu_de.php'
			</script>
		";
;?>