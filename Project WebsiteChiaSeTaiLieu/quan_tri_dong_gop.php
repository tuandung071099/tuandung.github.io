<!DOCTYPE HTML>

<html>

<head>
	<title>Quản trị đóng góp</title>
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
			width: 195px;
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
			width: 193px;
			height: auto;
			background: #ffffff;
			max-height: 200px;
			display: none;
			margin-top: 8px;
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
		$orderChuDe=null;
		$actual_link = "http://$_SERVER[HTTP_HOST]$_SERVER[REQUEST_URI]";
		$orderFile = null;
		$typeName=null;
		$fileName;
		//$id_nguoi_dung = $_SESSION['id_nguoi_dung'];
		//echo $id_nguoi_dung;exit();
		if (strpos($actual_link, '&l=') !== false) {
			$orderFile = $_GET["l"];
		}
		if (strpos($actual_link, '?t=') !== false) {
			$orderChuDe = $_GET["t"];
		}
		$ket_noi = mysqli_connect("remotemysql.com:3306", "MFjxl5C769", "4yl0CnAF1W", "MFjxl5C769");

		$sql = "
				SELECT *
				FROM chu_de
				ORDER BY ten_chu_de
				DESC
							";
		//echo $sql; exit();
		//echo $orderChuDe; exit();
		$noi_dung = mysqli_query($ket_noi, $sql);


		while ($row = mysqli_fetch_array($noi_dung)) {
			if ($orderChuDe ==  $row["id_chu_de"])
				$typeName = $row["ten_chu_de"];
			
		}
		
		if($orderChuDe == null)
		$typeName = "Tất cả";

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
						<a href="./quan_tri_tai_lieu.php?t=ngay_dang">Tài liệu</a>
						<a href="./quan_tri_chu_de.php">Chủ đề</a>
						<h2>Guest</h2>
						<a href="./quan_tri_dong_gop.php">Đóng góp</a>
					</div>
					<span style="font-size:30px;cursor:pointer" onclick="openNav()">&#9776; Quản trị hệ thống</span>
					<h2 style="text-align: center;">Đóng góp</h2>
					<h3 style="margin-left: 1020px;">Welcome admin |<a href="index.php">Logout</a> </h3>
					<div class="module_funtion">
						<div class="doc_file_total">
							Chủ đề: <?php echo $typeName; ?>
							<ul class="transition2">
								<li>
									<a rel="nofollow" href="./quan_tri_dong_gop.php
									<?php if ($orderFile !== null) {
										echo '?&l=' . "" . urldecode($orderFile);
									}; ?>" title="Tất cả">Tất cả</a>
								</li>
								<?php
								$ket_noi = mysqli_connect("remotemysql.com:3306", "MFjxl5C769", "4yl0CnAF1W", "MFjxl5C769");

								$sql = "
								SELECT *
								FROM chu_de
							";
								//echo $sql; exit();

								$noi_dung = mysqli_query($ket_noi, $sql);

								while ($row = mysqli_fetch_array($noi_dung)) {; ?>
									<li>
										<a rel="nofollow" href="./quan_tri_dong_gop.php?t=<?php echo $row["id_chu_de"]; ?>
									<?php if ($orderFile !== null) {
										echo '&l=' . "" . urldecode($orderFile);
									}; ?>" title="<?php echo $row["ten_chu_de"]; ?>"><?php echo $row["ten_chu_de"]; ?></a>
									</li>
								<?php
								}; ?>
							</ul>
						</div>
						<div class="doc_file_total">
							Loại file: <?php echo $fileName; ?>
							<ul class="transition2">
								<li>
									<a rel="nofollow" href="./quan_tri_dong_gop.php?t=<?php echo urldecode($orderChuDe); ?>" title="Tất cả">Tất cả</a>
								</li>
								<li>
									<a rel="nofollow" href="./quan_tri_dong_gop.php?t=<?php echo urldecode($orderChuDe); ?>&l=pdf" title=".pdf">.pdf</a>
								</li>
								<li>
									<a rel="nofollow" href="./quan_tri_dong_gop.php?t=<?php echo urldecode($orderChuDe); ?>&l=docx" title=".docx">.docx</a>
								</li>
								<li>
									<a rel="nofollow" href="./quan_tri_dong_gop.php?t=<?php echo urldecode($orderChuDe); ?>&l=pptx" title=".pptx">.pptx</a>
								</li>
							</ul>
						</div>
					</div>
					<table>
						<tr>
							<td style="font-weight: bold; text-align: center;">STT</td>
							<td style="width: 300px; font-weight: bold; text-align: center;">Tên tài liệu</td>
							<td style="font-weight: bold; text-align: center;">Chủ đề</td>
							<td style="font-weight: bold; text-align: center;">Định dạng</td>
							<td style="font-weight: bold; text-align: center;">Mô tả</td>
							<td style="font-weight: bold; text-align: center;">Người chia sẻ</td>
							<td style="font-weight: bold; text-align: center;">Ngày chia sẻ</td>
							<td style="font-weight: bold; text-align: center;" colspan="3">Thao tác</td>
						</tr>
						<?php
						if ($orderFile == null && $orderChuDe != null) {
							$sql = "
								SELECT dong_gop.*,ten_chu_de
								FROM dong_gop
								INNER JOIN chu_de
								ON chu_de.id_chu_de = dong_gop.id_chu_de
								WHERE dong_gop.id_chu_de= '$orderChuDe'
								ORDER BY ngay_chia_se
								DESC
							";
						} else if ($orderFile != null && $orderChuDe == null) {
							$sql = "
								SELECT dong_gop.*,ten_chu_de
								FROM dong_gop
								INNER JOIN chu_de
								ON chu_de.id_chu_de = dong_gop.id_chu_de
								WHERE dinh_dang = '$orderFile'
								ORDER BY ngay_chia_se
								DESC
							";
						} else if ($orderFile == null && $orderChuDe == null) {
							$sql = "
								SELECT dong_gop.*,ten_chu_de
								FROM dong_gop
								INNER JOIN chu_de
								ON chu_de.id_chu_de = dong_gop.id_chu_de
								ORDER BY ngay_chia_se
								DESC
							";
						} else {
							$sql = "
							SELECT dong_gop.*,ten_chu_de
							FROM dong_gop
							INNER JOIN chu_de
							ON chu_de.id_chu_de = dong_gop.id_chu_de
							WHERE dinh_dang = '$orderFile' AND dong_gop.id_chu_de= '$orderChuDe'
							ORDER BY ngay_chia_se
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
								<td style="width: 300px"><?php echo $row["tieu_de"]; ?></td>
								<td><?php echo $row["ten_chu_de"]; ?></td>
								<td><?php echo $row["dinh_dang"]; ?></td>
								<td><?php echo $row["mo_ta"]; ?></td>
								<td><?php echo $row["nguoi_chia_se"]; ?></td>
								<td><?php echo date("d/m/Y", strtotime($row["ngay_chia_se"])); ?></td>
								<td><a href="./quan_tri_dong_gop_duyet.php?id=<?php echo $row["id_dong_gop"]; ?>">Duyệt</a></td>
								<td><a href="./quan_tri_dong_gop_sua.php?id=<?php echo $row["id_dong_gop"]; ?>">Sửa</a></td>
								<td><a href="./quan_tri_dong_gop_xoa.php?id=<?php echo $row["id_dong_gop"]; ?>">Xóa</a></td>
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