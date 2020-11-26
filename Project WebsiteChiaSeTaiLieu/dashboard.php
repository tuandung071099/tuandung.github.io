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

		.searchBox input {
			border: 1px solid black;
			line-height: 25px;
			min-width: 350px;
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

		.dash1 {
			margin-top: 20px;
			width: 1138px;
			height: 300px;
		}

		.dash1 p {
			color: black;
			text-align: center;
			font-weight: bold;
			font-weight: i;
		}

		.dash1 li {
			float: left;
		}

		.dash1_unit img {
			float: left;
			width: 50px;
			height: 50px;
			margin-left: 204px;
			margin-top: -4px;
		}

		.dash1_unit img {
			float: left;
			width: 50px;
			height: 50px;
			margin-left: 204px;
			margin-top: -4px;
		}

		.dash1_unit table {
			margin-top: 1px;
		}

		.dash2_left {
			margin-top: 20px;
			float: left;
			border: 1px solid black;
			width: 530px;
			height: 300px;
		}

		.dash2_right {
			margin-top: 20px;
			float: right;
			border: 1px solid black;
			width: 530px;
			height: 300px;
		}

		.unit1,
		.unit2,
		.unit3 {
			width: 200px;
			height: 175px;
			float: left;
			margin: 48px 0px 0px -120px;

		}

		.unit1 {
			margin: 40px 0 0 -122px;
		}

		.unit2 table {
			margin: 0 0 0 0;
		}

		.unit3 {
			margin: 50px 0 0 -122px;
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
					<h2 style="text-align: center;">Dashboard</h2>
					<h3 style="margin-left: 1020px;">Welcome admin |<a href="index.php">Logout</a> </h3>
					<div class="dash1">
						<h3 style="font-size: 20px;">Trending</h2>
							<div class="dash1_unit">
								<img style="margin-top: -9px ;" src="./images/treding.png">
								<div class="unit1">
									<p>Được quan tâm nhất</p>
									<table style="width: 203px; height: 200px ;margin-left: -1px; background-color: #febf63;">
										<tr>
											<td style="font-weight: bold; text-align: center;">Tài liệu</td>
											<td style="font-weight: bold; text-align: center; width: 43px;">Lượt xem</td>
											<td style="font-weight: bold; text-align: center; width: 43px;">Lượt tải</td>
										</tr>
										<?php
										$conn = mysqli_connect("remotemysql.com:3306", "MFjxl5C769", "4yl0CnAF1W", "MFjxl5C769");

										$sql = "
										SELECT *
										FROM tai_lieu
										ORDER BY so_luot_tai + so_luot_xem desc
										LIMIT 3
											";
										$noi_dung = mysqli_query($conn, $sql);
										while ($row = mysqli_fetch_array($noi_dung)) {; ?>
											<tr>
												<td><a href="./chi_tiet.php?id=<?php echo $row["id_tai_lieu"]; ?>"><?php echo $row["tieu_de"]; ?></a></td>
												<td><?php echo $row["so_luot_xem"]; ?></td>
												<td><?php echo $row["so_luot_tai"]; ?></td>
											</tr>
										<?php
										}; ?>
									</table>
								</div>
							</div>
							<div class="dash1_unit">
								<img style="margin-top: -7px ;" src="./images/Topic-Logo-1.png">
								<div class="unit2">
									<p>Chủ đề hot</p>
									<table style="width: 203px; height: 200px ;margin-left: -1px; background-color: #ede682;">
										<tr>
											<td style="font-weight: bold; text-align: center;">Chủ đề</td>
											<td style="font-weight: bold; text-align: center; width: 43px;">Số tài liệu</td>
										</tr>
										<?php
										$sql = "
												SELECT ten_chu_de,COUNT(*) as 'so_tai_lieu'
												FROM tai_lieu 
												INNER JOIN chu_de 
												ON chu_de.id_chu_de = tai_lieu.id_chu_de 
												GROUP BY chu_de.id_chu_de
												ORDER BY COUNT(*) DESC
												LIMIT 3
											";
										$noi_dung = mysqli_query($conn, $sql);
										while ($row = mysqli_fetch_array($noi_dung)) {; ?>
											<tr>
												<td><?php echo $row["ten_chu_de"]; ?></td>
												<td><?php echo $row["so_tai_lieu"]; ?></td>
											</tr>
										<?php
										}; ?>
									</table>
								</div>
							</div>
							<div class="dash1_unit">
								<img class="sup" style="margin-top: -7x ;margin-right: -7x ;" src="./images/support.png">
								<div class="unit3">
									<p>Best chia sẻ</p>
									<table style="width: 203px; height: 200px ;margin-left: -1px; background-color: #ade498;">
										<tr>
											<td style="font-weight: bold; text-align: center;">Người chia sẻ</td>
											<td style="font-weight: bold; text-align: center; width: 43px;">Số tài liệu</td>
										</tr>
										<?php
										$conn = mysqli_connect("remotemysql.com:3306", "MFjxl5C769", "4yl0CnAF1W", "MFjxl5C769");

										$sql = "
												SELECT nguoi_chia_se,count(*) as 'so_tai_lieu'
												FROM dong_gop 
												GROUP BY nguoi_chia_se
												ORDER BY COUNT(*) DESC
												LIMIT 3
											";
										$noi_dung = mysqli_query($conn, $sql);
										while ($row = mysqli_fetch_array($noi_dung)) {; ?>
											<tr>
												<td><?php echo $row["nguoi_chia_se"]; ?></td>
												<td><?php echo $row["so_tai_lieu"]; ?></td>
											</tr>
										<?php
										}; ?>
									</table>
								</div>
							</div>
					</div>
				<div>
				<a href="http://mis.hvnh.edu.vn/">
				<img style="margin: 70px 0px 0px 235px ;" src="./images/mis_banner.png" alt="">
				</a>
				</div>
			</div>
		</div>
	</div>
	<?php
	include("footer.php");; ?>
</body>

</html>