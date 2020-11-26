<!DOCTYPE HTML>

<html>

<head>
	<title>Thêm chủ đề</title>
	<meta http-equiv="content-type" content="text/html; charset=utf-8" />
	<meta name="description" content="" />
	<meta name="keywords" content="" />
	<noscript>
		<link rel="stylesheet" href="css/5grid/core.css" />
		<link rel="stylesheet" href="css/5grid/core-desktop.css" />
		<link rel="stylesheet" href="css/5grid/core-1200px.css" />
		<link rel="stylesheet" href="css/5grid/core-noscript.css" />
		<link rel="stylesheet" href="css/style.css" />
		<link rel="stylesheet" href="css/style-desktop.css" />
	</noscript>
	<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script>
	<script src="css/5grid/init.js?use=mobile,desktop,1000px&amp;mobileUI=1&amp;mobileUI.theme=none&amp;mobileUI.openerWidth=52"></script>
	<!--[if IE 9]><link rel="stylesheet" href="css/style-ie9.css" /><![endif]-->
	<style>
		body {
			color: #000000;
		}

		button {
			background-color: #007c8b;
			width: 1150px;
			border: none;
			color: white;
			padding: 15px 32px;
			text-align: center;
			text-decoration: none;
			display: inline-block;
			font-size: 16px;
			margin: 14px 0px;
			cursor: pointer;
		}
	</style>
</head>

<body class="onecolumn">
	<div id="wrapper">
		<?php
		include("header.php");; ?>
		<div id="page-wrapper" class="5grid-layout">
			<div class="row" id="content">
				<h1 style="text-align: center; padding-bottom: 20px; font-size: 30px">THÊM MỚI CHỦ ĐỀ</h1>
				<form method="POST" action="./quan_tri_chu_de_them_thuc_hien.php" enctype="multipart/form-data">
					<p>
						Tên chủ đề:<br>
						<input type="text" name="txtTenCD" style="width: 100%; margin-top: 1px">
					</p>
					<p>
						Phân loại:<br>
						<select name="txtPhanLoai" style="width: 1150px;">
							<?php
							// 1. Chuỗi kết nối đến CSDL
							$ket_noi = mysqli_connect("remotemysql.com:3306", "MFjxl5C769", "4yl0CnAF1W", "MFjxl5C769");

							// 2. Viết câu lệnh SQL để lấy ra dữ liệu mong muốn
							$sql = "
								SELECT *
								FROM  loai_tai_lieu
								ORDER BY ten_loai_tai_lieu
							";
							
							// 3. Thực hiện truy vấn để lấy ra các dữ liệu mong muốn
							$noi_dung = mysqli_query($ket_noi, $sql);

							// 4. Hiển thị dữ liệu mong muốn
							$i = 0;
							while ($row = mysqli_fetch_array($noi_dung)) {
								$i++;; ?>
								<option value="<?php echo $row["id_loai_tai_lieu"]; ?>"><?php echo $row["ten_loai_tai_lieu"]; ?></option>
							<?php
							}; ?>
						</select>
					</p>
					<button type="submit">Thêm mới</button>
				</form>
			</div>
		</div>
		<?php
			include("footer.php");
		;?>
</body>

</html>