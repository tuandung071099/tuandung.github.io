<!DOCTYPE HTML>

<html>

<head>
	<title>Sửa tài liệu</title>
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
			width: 100%;
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
				<h1 style="text-align: center; padding-bottom: 20px; font-size: 30px">CẬP NHẬT ĐÓNG GÓP</h1>
				<form method="POST" action="./quan_tri_dong_gop_sua_thuc_hien.php" enctype="multipart/form-data">
					<?php
					// 1. Chuỗi kết nối đến CSDL
					$ket_noi = mysqli_connect("remotemysql.com:3306", "MFjxl5C769", "4yl0CnAF1W", "MFjxl5C769");
					$id_dong_gop = $_GET["id"];
					// 2. Viết câu lệnh SQL để lấy ra dữ liệu mong muốn
					$sql = "
								SELECT *
								FROM  dong_gop
								WHERE id_dong_gop='" . $id_dong_gop . "'
							";

					// 3. Thực hiện truy vấn để lấy ra các dữ liệu mong muốn
					$noi_dung = mysqli_query($ket_noi, $sql);
					$row = mysqli_fetch_array($noi_dung);
					$id_chu_de = $row["id_chu_de"];; ?>
					<input type="hidden" name="txtID" value="<?php echo $row["id_dong_gop"]; ?>">
					<p>
						Tên tài liệu:<br>
						<input type="text" name="txtTenTaiLieu" style="width: 100%; margin-top: 1px" value="<?php echo $row["tieu_de"]; ?>">
					</p>
					<p>
						Chủ đề:<br>
						<select name="txtChuDe" style="width: 1150px;">
							<?php
							$sql = "
								SELECT *
								FROM chu_de
							";
							// 3. Thực hiện truy vấn để lấy ra các dữ liệu mong muốn
							$noi_dung = mysqli_query($ket_noi, $sql);

							// 4. Hiển thị dữ liệu mong muốn
							while ($row = mysqli_fetch_array($noi_dung)) {; ?>
								<option value="<?php echo $row["id_chu_de"]; ?>" <?php if ($row["id_chu_de"] == $id_chu_de) echo 'selected'; ?>><?php echo $row["ten_chu_de"]; ?></option>
							<?php
							}; ?>
						</select>
					</p>
					<?php
					// 2. Viết câu lệnh SQL để lấy ra dữ liệu mong muốn
					$sql = "
								SELECT *
								FROM  dong_gop
								WHERE id_dong_gop='" . $id_dong_gop . "'
							";

					// 3. Thực hiện truy vấn để lấy ra các dữ liệu mong muốn
					$noi_dung = mysqli_query($ket_noi, $sql);
					$row = mysqli_fetch_array($noi_dung);; ?>
					<p>
						<p>
							Định dạng:<br>
							<select name="txtDinhDang" style="width: 1150px">
								<option value="pdf" <?php if ($row["dinh_dang"] == 'pdf') echo 'selected'; ?>>.PDF</option>
								<option value="docx" <?php if ($row["dinh_dang"] == 'docx') echo 'selected'; ?>>.DOCX</option>
								<option value="pptx" <?php if ($row["dinh_dang"] == 'pptx') echo 'selected'; ?>>.PPTX</option>
							</select>
						</p>
						<p>
							Số trang:<br>
							<input type="text" name="txtSoTrang" style="width: 100%; margin-top: 1px" value="<?php echo $row["so_trang"]; ?>">
						</p>
						<p>
							Mô tả:<br>
							<textarea name="txtMoTa" style="width:250px;height:50px;"><?php echo $row["mo_ta"]; ?></textarea>
						</p>
						<p>
							Người chia sẻ:<br>
							<input type="text" name="txtNguoiChiaSe" style="width: 100%;" value="<?php echo $row["nguoi_chia_se"]; ?>">
						</p>
						<p>
							File tải liệu:<br>
							<input type="file" name="txtFileTaiLieu" style="width: 100%;">
						</p>
						<p>
							File ảnh:<br>
							<input type="file" name="txtFileAnh" style="width: 100%;">
						</p>
						<button type="submit">Cập nhật</button>
				</form>
			</div>
		</div>
		<?php
			include("footer.php");
		;?>
</body>

</html>