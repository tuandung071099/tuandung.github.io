<!DOCTYPE HTML>

<html>

<head>
	<title>Quản trị tài liệu</title>
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
		table,
		td {
			border: 1px solid black;
			border-collapse: collapse;
		}

		table {
			width: 1142px;
		}

		td {
			height: 50px;
			vertical-align: middle;
			font-size: 12px;
			text-align: center;
			color: #000000;
		}

		body {
			font-family: "Lato", sans-serif;
		}

		.sidenav {
			height: 100%;
			width: 0;
			position: fixed;
			z-index: 1;
			top: 0;
			left: 0;
			background-color: #007e8d54;
			overflow-x: hidden;
			transition: 0.5s;
			padding-top: 60px;
		}

		.sidenav a {
			padding: 8px 8px 8px 32px;
			text-decoration: none;
			font-size: 25px;
			color: #ffffff;
			display: block;
			transition: 0.3s;
		}

		.sidenav a:hover {
			color: #000000;
		}

		.sidenav .closebtn {
			position: absolute;
			top: 0;
			right: 25px;
			font-size: 36px;
			margin-left: 50px;
		}

		@media screen and (max-height: 450px) {
			.sidenav {
				padding-top: 15px;
			}

			.sidenav a {
				font-size: 18px;
			}
		}

		.module_funtion {
			width: 1140px;
			height: 42px;
			background: #fff;
			border: 1px solid #e8e8e8;
			margin: 16px 0;
			position: relative;
		}

		[class^=doc_file] {
			position: relative;
			height: 30px;
			width: 135px;
			min-width: 84px;
			border: 1px solid #e8e8e8;
			border-radius: 5px;
			font-size: 13px;
			color: #00a888;
			padding: 6px 0 5px 5px;
			box-sizing: border-box;
			margin: 6px 0 8px 10px;
			cursor: pointer;
			float: left;
		}

		ul.transition2 {
			width: 133px;
			height: auto;
			background: #ffffff;
			min-height: auto;
			display: none;
			margin-top: 7px;
			margin-left: -5px;
			border-left: 1px solid #00a888;
			border-bottom: 1px solid #00a888;
			border-right: 1px solid #00a888;
			overflow-y: scroll;
		}

		ul.transition2 li {
			list-style: none;
		}

		ul.transition2 li a {
			color: #999;
			text-decoration: none;
			display: block;
			border-bottom: 1px solid #ccc;
			line-height: 40px;
			text-indent: 10px;
		}

		[class^=doc_file]:hover {
			background: #00a888;
			color: #fff;
			border: #00a888;
		}

		[class^=doc_file]:hover>ul.transition2 {
			display: block;
		}

		ul.transition2 li a:hover {
			background: #00a888;
			color: #fff;
		}
	</style>

	<script>
		function openNav() {
			document.getElementById("mySidenav").style.width = "250px";
		}

		function closeNav() {
			document.getElementById("mySidenav").style.width = "0";
		}
	</script>

</head>

<body class="onecolumn">
	<div id="wrapper">
		<?php
		$orderType = $_GET["t"];
		$actual_link = "http://$_SERVER[HTTP_HOST]$_SERVER[REQUEST_URI]";
		$orderFile = null;
		$typeName;
		$fileName;
		//$id_nguoi_dung = $_SESSION['id_nguoi_dung'];
		//echo $id_nguoi_dung;exit();
		if (strpos($actual_link, '&l=') !== false) {
			$orderFile = $_GET["l"];
		}
		switch ($orderType) {
			case "ngay_dang":
				$typeName = "Mới đăng";
				break;
			case "so_luot_xem":
				$typeName = "Xem nhiều";
				break;
			case "so_luot_tai":
				$typeName = "Tải nhiều";
				break;
			default:
				$typeName = "Mới đăng";;
		}
		switch ($orderFile) {
			case "pdf":
				$fileName = "pdf";
				break;
			case "docx":
				$fileName = "docx";
				break;
			case "pptx":
				$fileName = "pptx";
				break;
			default:
				$fileName = "Tất cả";;
		}
		//echo $orderFile;exit();
		include("./header.php");; ?>
		<div id="page-wrapper" class="5grid-layout">
			<div class="row" id="content">
				<div class="12u">
					<div id="mySidenav" class="sidenav">
						<h2>Admin</h2>
						<a href="javascript:void(0)" class="closebtn" onclick="closeNav()">&times;</a>
						<a href="dashboard.php">Dashboard</a>
						<a href="quan_tri_tai_lieu.php?t=ngay_dang">Tài liệu</a>
						<a href="quan_tri_chu_de.php">Chủ đề</a>
						<h2>Guest</h2>
						<a href="quan_tri_dong_gop.php">Đóng góp</a>
					</div>
					<span style="font-size:30px;cursor:pointer" onclick="openNav()">&#9776; Quản trị hệ thống</span>
					<h2 style="text-align: center;">Tài liệu</h2>
					<h3 style="margin-left: 1020px;">Welcome admin |<a href="index.php">Logout</a> </h3>
					<div class="module_funtion">
						<div class="doc_file_total">
							Tổng hợp: <?php echo $typeName; ?>
							<ul class="transition2">
								<li>
									<a rel="nofollow" href="./quan_tri_tai_lieu.php?t=ngay_dang
									<?php if ($orderFile !== null) {
										echo '&l=' . "" . urldecode($orderFile);
									}; ?>" title="Mới đăng">Mới đăng</a>
								</li>
								<li>
									<a rel="nofollow" href="./quan_tri_tai_lieu.php?t=so_luot_xem
									<?php if ($orderFile !== null) {
										echo '&l=' . "" . urldecode($orderFile);
									}; ?>" title="Xem nhiều">Xem nhiều</a>
								</li>
								<li>
									<a rel="nofollow" href="./quan_tri_tai_lieu.php?t=so_luot_tai
									<?php if ($orderFile !== null) {
										echo '&l=' . "" . urldecode($orderFile);
									}; ?>" title="Tải nhiều">Tải nhiều</a>
								</li>
							</ul>
						</div>
						<div class="doc_file_total">
							Loại file: <?php echo $fileName; ?>
							<ul class="transition2">
								<li>
									<a rel="nofollow" href="./quan_tri_tai_lieu.php?t=<?php echo urldecode($orderType); ?>" title="Tất cả">Tất cả</a>
								</li>
								<li>
									<a rel="nofollow" href="./quan_tri_tai_lieu.php?t=<?php echo urldecode($orderType); ?>&l=pdf" title=".pdf">.pdf</a>
								</li>
								<li>
									<a rel="nofollow" href="./quan_tri_tai_lieu.php?t=<?php echo urldecode($orderType); ?>&l=docx" title=".docx">.docx</a>
								</li>
								<li>
									<a rel="nofollow" href="./quan_tri_tai_lieu.php?t=<?php echo urldecode($orderType); ?>&l=pptx" title=".pptx">.pptx</a>
								</li>
							</ul>
						</div>
					</div>
					<p style="text-align: right; font-weight: bold;"><a href="./quan_tri_tai_lieu_them.php">Thêm mới</a></p>
					<table>
						<tr>
							<td style="font-weight: bold; text-align: center;">STT</td>
							<td style="width: 300px; font-weight: bold; text-align: center;">Tên tài liệu</td>
							<td style="font-weight: bold; text-align: center;">Chủ đề</td>
							<td style="font-weight: bold; text-align: center;">Định dạng</td>
							<td style="font-weight: bold; text-align: center;">Ngày đăng</td>
							<td style="font-weight: bold; text-align: center;">Số lượt tải</td>
							<td style="font-weight: bold; text-align: center;">Số lượt xem</td>
							<td style="font-weight: bold; text-align: center;" colspan="2">Thao tác</td>
						</tr>
						<?php
						// 1. Chuỗi kết nối đến CSDL
						$ket_noi = mysqli_connect("remotemysql.com:3306", "MFjxl5C769", "4yl0CnAF1W", "MFjxl5C769");;

						// 2. Viết câu lệnh SQL để lấy ra dữ liệu mong muốn
						if ($orderFile == null) {
							$sql = "
								SELECT tai_lieu.*,ten_chu_de
								FROM tai_lieu
								INNER JOIN chu_de
								ON chu_de.id_chu_de = tai_lieu.id_chu_de
								ORDER BY $orderType
								DESC
							";
						} else {
							$sql = "
							SELECT tai_lieu.*,ten_chu_de
							FROM tai_lieu
							INNER JOIN chu_de
							ON chu_de.id_chu_de = tai_lieu.id_chu_de
							WHERE ma_dinh_dang = '$orderFile' 
							ORDER BY $orderType
							DESC
						";
						}

						//echo $sql; exit();
						// 3. Thực hiện truy vấn để lấy ra các dữ liệu mong muốn
						$noi_dung = mysqli_query($ket_noi, $sql);

						// 4. Hiển thị dữ liệu mong muốn
						$i = 0;
						while ($row = mysqli_fetch_array($noi_dung)) {
							$i++;; ?>
							<tr>
								<td><?= $i; ?></td>
								<td style="width: 300px"><a href="./chi_tiet.php?id=<?php echo $row["id_tai_lieu"]; ?>"><?php echo $row["tieu_de"]; ?></a></td>
								<td><?php echo $row["ten_chu_de"]; ?></td>
								<td><?php echo $row["ma_dinh_dang"]; ?></td>
								<td><?php echo date("d/m/Y",strtotime($row["ngay_dang"])); ?></td>
								<td><?php echo $row["so_luot_tai"]; ?></td>
								<td><?php echo $row["so_luot_xem"]; ?></td>
								<td><a href="./quan_tri_tai_lieu_sua.php?id=<?php echo $row["id_tai_lieu"]; ?>">Sửa</a></td>
								<td><a href="./quan_tri_tai_lieu_xoa.php?id=<?php echo $row["id_tai_lieu"]; ?>">Xóa</a></td>
							</tr>
						<?php
						}; ?>
					</table>
				</div>
			</div>
		</div>
		<?php
			include("footer.php");
		;?>
</body>

</html>