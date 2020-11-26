<?php 
	$ket_noi = mysqli_connect("remotemysql.com:3306", "MFjxl5C769", "4yl0CnAF1W", "MFjxl5C769");

	$id_chu_de=$_GET["id"];

	$sql = "
		DELETE
		FROM chu_de
		WHERE id_chu_de='".$id_chu_de."'
	";

	mysqli_query($ket_noi, $sql);


		echo 
		"
			<script type='text/javascript'>
				window.alert('Bạn đã xóa chủ đề thành công.');
			</script>
		";

		echo 
		"
			<script type='text/javascript'>
				window.location.href = './quan_tri_chu_de.php'
			</script>
		";
;?>