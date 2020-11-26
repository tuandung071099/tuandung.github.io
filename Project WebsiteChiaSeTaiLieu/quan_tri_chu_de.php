<!DOCTYPE HTML>

<html>

<head>
	<title>Quản trị chủ đề</title>
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

		.searchBox {
			float: left;
			padding: 2px 24px 2px 2px;
			border-radius: 3px;
			position: relative;
			margin-top: 7px;
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
			width: 200px;
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
			width: 198px;
			height: auto;
			background: #ffffff;
			max-height: 250px;
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

		.searchBox input {
			border: 1px solid black;
			line-height: 25px;
			max-width: 200px;
			height: 25px;
			float: left;
			margin-left: -2px;
		}

		.searchBox>a>img {
			background-position: -73px -83px;
			width: 20px;
			height: 20px;
			margin: 7px 0px 0px -20px;
			float: left;
		}

		.searchBox i:hover {
			color: #2cb7ab;
		}

		.icon,
		img[class^=icon] {
			background-repeat: no-repeat;
			display: inline-block;
			vertical-align: text-top;
		}

		#content img {
			border: #ffffff;
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
		include("header.php");; ?>
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
					<h2 style="text-align: center;">Chủ đề</h2>
					<h3 style="margin-left: 1020px;">Welcome admin |<a href="index.php">Logout</a> </h3>
					<div class="module_funtion">
						<div class="doc_file_total">
							<?php
							$typeName = null;
							$orderChuDe = null;
							$actual_link = "http://$_SERVER[HTTP_HOST]$_SERVER[REQUEST_URI]";
							if (strpos($actual_link, '?t=') !== false) {
								$orderChuDe = $_GET["t"];
							}
							$ket_noi = mysqli_connect("remotemysql.com:3306", "MFjxl5C769", "4yl0CnAF1W", "MFjxl5C769");
					
							$sql = "
									SELECT *
									FROM loai_tai_lieu
									ORDER BY ten_loai_tai_lieu
									DESC
												";
							//echo $sql; exit();
							//echo $orderChuDe; exit();
							$noi_dung = mysqli_query($ket_noi, $sql);
							while ($row = mysqli_fetch_array($noi_dung)) {
								if ($orderChuDe ==  $row["id_loai_tai_lieu"])
									$typeName = $row["ten_loai_tai_lieu"];
							}
					
							if ($orderChuDe == null)
								$typeName = "Tất cả";
							;?>
							Phân loại: <?php echo $typeName; ?>
							<ul class="transition2">
								<li>
									<a rel="nofollow" href="./quan_tri_chu_de.php" title="Tất cả">Tất cả</a>
								</li>
								<?php
										

								//echo $sql; exit();

								$noi_dung = mysqli_query($ket_noi, $sql);

								while ($row = mysqli_fetch_array($noi_dung)) {; ?>
									<li>
										<a rel="nofollow" href="./quan_tri_chu_de.php?t=<?php echo $row["id_loai_tai_lieu"]; ?>"><?php echo $row["ten_loai_tai_lieu"]; ?></a>
									</li>
								<?php
								}; ?>
							</ul>
						</div>
					</div>
					<p style="text-align: right; font-weight: bold;"><a href="./quan_tri_chu_de_them.php">Thêm mới</a></p>
					<table>
						<tr>
							<td style="font-weight: bold; text-align: center;">STT</td>
							<td style="font-weight: bold; text-align: center;">Chủ đề</td>
							<td style="font-weight: bold; text-align: center;">Phân loại</td>
							<td style="font-weight: bold; text-align: center;" colspan="2">Thao tác</td>
						</tr>
						<?php
						if ($orderChuDe != null) {
							$sql = "
							SELECT *
							FROM chu_de
							INNER JOIN loai_tai_lieu
							ON chu_de.id_loai_tai_lieu = loai_tai_lieu.id_loai_tai_lieu
							WHERE loai_tai_lieu.id_loai_tai_lieu = '$orderChuDe'
							ORDER BY id_chu_de DESC
							";
						} else {
							$sql = "
								SELECT *
								FROM chu_de
								INNER JOIN loai_tai_lieu
								ON chu_de.id_loai_tai_lieu = loai_tai_lieu.id_loai_tai_lieu
								ORDER BY id_chu_de DESC
							";
						}

						//echo $sql;exit();
						// 3. Thực hiện truy vấn để lấy ra các dữ liệu mong muốn
						$noi_dung = mysqli_query($ket_noi, $sql);

						// 4. Hiển thị dữ liệu mong muốn
						$i = 0;
						while ($row = mysqli_fetch_array($noi_dung)) {
							$i++;; ?>
							<tr>
								<td><?= $i; ?></td>
								<td><?php echo $row["ten_chu_de"]; ?></td>
								<td><?php echo $row["ten_loai_tai_lieu"]; ?></td>
								<td><a href="./quan_tri_chu_de_sua.php?id=<?php echo $row["id_chu_de"]; ?>">Sửa</a></td>
								<td><a href="./quan_tri_chu_de_xoa.php?id=<?php echo $row["id_chu_de"]; ?>">Xóa</a></td>
							</tr>
						<?php
						}; ?>
					</table>
				</div>
			</div>
		</div>
		<?php
		include("footer.php");; ?>
</body>

</html>