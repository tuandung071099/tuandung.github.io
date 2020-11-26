<?php 
$id_tai_lieu=$_GET["id"];
$ket_noi = mysqli_connect("remotemysql.com:3306", "MFjxl5C769", "4yl0CnAF1W", "MFjxl5C769");
$sql = "
SELECT *
FROM tai_lieu
WHERE id_tai_lieu='".$id_tai_lieu."'
";
$noi_dung = mysqli_query($ket_noi, $sql);
$view = "
UPDATE tai_lieu SET so_luot_tai = so_luot_tai + 1 WHERE id_tai_lieu = $id_tai_lieu
";
mysqli_query($ket_noi, $view);
while ($row = mysqli_fetch_array($noi_dung)) {
	$file = $row["file"]; };
	echo 
	"<script type='text/javascript'>
	window.location.href = './pdf/" .$file."'
	</script>	";
	;?>