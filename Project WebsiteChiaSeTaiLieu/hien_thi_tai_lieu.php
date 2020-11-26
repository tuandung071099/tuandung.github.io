<!DOCTYPE HTML>
<!--
	Affinity by TEMPLATED
	templated.co @templatedco
	Released for free under the Creative Commons Attribution 3.0 license (templated.co/license)
-->
<html>
<head>
<title>Affinity by TEMPLATED</title>
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
</head><body>
<div id="wrapper">
		<?php
			include("header.php");
		;?>
	<div  style="background-color: #f8f8f8;" id="page-wrapper" class="5grid-layout">
		<div class="row">
			<!-- BẮT ĐẦU CONTENT -->
			<div class="9u col-md-3">
				<div id="content">
					<div style="border: 1px solid;width: 715px;height: 35px; margin-left:60px">
						<form method="post" action="#" enctype="multipart/form-data">
							<select style="border: 1px solid;width: 150px;height: 25px;" name="SelectedOption">
								<option value="Default">Mặc định</option>
								<option value="saab">Saab</option>
								<option value="fiat" selected>Fiat</option>
								<option value="audi">Audi</option>
							</select>
						</form>
					</div>
					
					<div style="clear: both;">
						<?php 
						$ket_noi = mysqli_connect("remotemysql.com:3306", "MFjxl5C769", "4yl0CnAF1W", "MFjxl5C769");
						$SelectedOption = (isset($_POST['SelectedOption']) ? $_POST['SelectedOption']: null);
						$sql = "
							SELECT *
							FROM nguoi_dung
							ORDER BY id_nguoi_dung ASC
						";

						$noi_dung = mysqli_query($ket_noi, $sql);

						$i=0;
						while ($row = mysqli_fetch_array($noi_dung)) {
						$i++;
						;?>
						<div class="cbox1" style="float: left;width: 200px;height: 310px; padding: 5px; margin: 20px; margin-left:60px">
							<a href="./chi_tiet.php?id=<?php echo $row["id_nguoi_dung"];?>"><div class="post">
								<h2 style="text-align: center"></h2>
								<img src="../img/<?php 
								if ($row["anh_nguoi_dung"]<>"") {
									echo $row["anh_nguoi_dung"];
								} else {
									echo "no_image.png";
								}
							// ;?>" width="180px" height="auto">
							<p><?php echo $row["ten_dang_nhap"];?></p>
							</div></a>
						</div>

						<?php if (!$row = mysqli_fetch_array($noi_dung)){break;}?>
						<div class="cbox1" style="float: left;width: 200px;height: 310px; padding: 5px; margin: 20px">
							<a href="./chi_tiet.php?id=<?php echo $row["id_nguoi_dung"];?>"><div class="post">
								<h2 style="text-align: center"></h2>
								<img src="../img/<?php 
								if ($row["anh_nguoi_dung"]<>"") {
									echo $row["anh_nguoi_dung"];
								} else {
									echo "no_image.png";
								}
							// ;?>" width="180px" height="auto">
							<p><?php echo $row["ten_dang_nhap"];?></p>
							</div></a>
						</div>
						
						<?php if (!$row = mysqli_fetch_array($noi_dung)){break;} ?>
						<div class="cbox1" style="float: left;width: 200px;height: 310px; padding: 5px; margin: 20px">
							<a href="./chi_tiet.php?id=<?php echo $row["id_nguoi_dung"];?>"><div class="post">
								<h2 style="text-align: center"></h2>
								<img src="../img/<?php 
								if ($row["anh_nguoi_dung"]<>"") {
									echo $row["anh_nguoi_dung"];
								} else {
									echo "no_image.png";
								}
							// ;?>" width="180px" height="auto">
							<p><?php echo $row["ten_dang_nhap"];?></p>
							</div></a>
						</div>
						<?php
						}
						;?>
					</div>
				</div>
			</div>
			<!-- KẾT THÚC CONTENT -->

			<!-- BẮT ĐẦU SIDEBAR -->
			<div class="3u col-md-9">
				<div id="sidebar2">
					<section>
						<div class="sbox1">
							<h2>Nhiều người xem</h2>
							<ul class="style1">
							<?php 
								$ket_noi = mysqli_connect("localhost", "root", "", "quanlygiangvien");

								$sql = "
								SELECT * 
								FROM giangvien 
								ORDER BY MaGV 
								ASC limit 7
								";
								//echo $sql;exit;
								$noi_dung = mysqli_query($ket_noi, $sql);

								$i=0;
								while ($row = mysqli_fetch_array($noi_dung)) {
								$i++;
							;?>
								<li><a href="./onecolumn.php?id=<?php echo $row["MaGV"];?>"><?php echo $row["TenGV"];?></a></li>
								<?php
								}
								;?>
							</ul>
						</div>
						<div class="sbox2">
							<h2>Đã xem gần đây</h2>
							<ul class="style1">
							<?php 
								$ket_noi = mysqli_connect("localhost", "root", "", "quanlygiangvien");

								$sql = "
								SELECT * 
								FROM giangvien 
								ORDER BY MaGV 
								ASC limit 7
								";
								//echo $sql;exit;
								$noi_dung = mysqli_query($ket_noi, $sql);

								$i=0;
								while ($row = mysqli_fetch_array($noi_dung)) {
								$i++;
							;?>
								<li><a href="./onecolumn.php?id=<?php echo $row["MaGV"];?>"><?php echo $row["TenGV"];?></a></li>
								<?php
								}
								;?>
							</ul>
						</div>
					</section>
				</div>
			</div>
			<!-- KẾT THÚC SIDEBAR -->
		</div>
	</div>
	<div class="5grid-layout">
		<div class="row" id="footer-content">
			<div class="6u" id="box1">
				<section>
					<h2>Maecenas luctus lectus</h2>
					<div>
						<p><img src="images/pics05.jpg" alt="" width="180" height="120" class="imgleft">In posuere eleifend odio. Quisque semper augue mattis wisi. Maecenas ligula. Pellentesque viverra vulputate enim. Aliquam erat volutpat. Pellentesque tristique ante ut risus. Quisque dictum. Integer nisl risus, sagittis convallis, rutrum id, elementum congue, nibh. Suspendisse dictum porta lectus. Donec placerat odio vel elit. Nullam ante orci, pellentesque eget, tempus quis, ultrices in, est. Curabitur sit amet nulla. Nam in massa. Sed vel tellus. Curabitur sem urna, consequat vel, suscipit in, mattis placerat, nulla. Sed ac leo. Pellentesque imperdiet. Etiam neque. Vivamus consequat lorem at nisl. Nullam non wisi a sem semper eleifend. Donec mattis libero eget urna. Duis pretium velit ac mauris. Proin eu wisi suscipit nulla suscipit interdum. Aenean lectus lorem, imperdiet at, ultrices eget, ornare et, wisi. </p>
					</div>
				</section>
			</div>
			<div class="3u" id="box2">
				<section>
					<h2>Donec dictum metus</h2>
					<ul class="style4">
						<li class="first"><a href="#">Pellentesque quis elit non lectus gravida blandit sed dolore.</a></li>
						<li><a href="#">Lorem ipsum dolor sit amet, consectetuer adipiscing elit.</a></li>
						<li><a href="#">Phasellus nec erat sit amet nibh pellentesque congue.</a></li>
						<li><a href="#">Cras vitae metus aliquam risus pellentesque pharetra.</a></li>
					</ul>
				</section>
			</div>
			<div class="3u" id="box3">
				<section>
					<h2>Nulla luctus eleifend</h2>
					<ul class="style4">
						<li class="first"><a href="#">Pellentesque quis elit non lectus gravida blandit sed dolore.</a></li>
						<li><a href="#">Lorem ipsum dolor sit amet, consectetuer adipiscing elit.</a></li>
						<li><a href="#">Phasellus nec erat sit amet nibh pellentesque congue.</a></li>
						<li><a href="#">Cras vitae metus aliquam risus pellentesque pharetra.</a></li>
					</ul>
				</section>
			</div>
		</div>
	</div>
</div>
<div id="copyright" class="5grid-layout">
	<section>
		<p>&copy; Your Site Name | Images: <a href="http://fotogrph.com/">Fotogrph</a> | Design: <a href="http://templated.co/">TEMPLATED</a></p>
	</section>
</div>
</body>
</html>