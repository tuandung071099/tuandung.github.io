<!DOCTYPE HTML>
<!--
	Affinity by TEMPLATED
	templated.co @templatedco
	Released for free under the Creative Commons Attribution 3.0 license (templated.co/license)
-->
<html>
<head>
	<?php
	$conn = mysqli_connect("remotemysql.com:3306", "MFjxl5C769", "4yl0CnAF1W", "MFjxl5C769");
	$id_the_loai=$_GET["id"];
	$getTheLoai = "
	SELECT *
	FROM chu_de
	WHERE id_chu_de='".$id_loai_tai_lieu."'
	";						
	$theLoaiQuerry = mysqli_query($conn, $getTheLoai);
	while ($row = mysqli_fetch_array($theLoaiQuerry)) {
		$ten_the_loai = $row["ten_loai_tai_lieu"];
	};
	?>
	<title>Danh mục tài liệu theo thể loại <?php echo $ten_the_loai ?></title>
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
	<script src="css/5grid/init.js?use=mobile,desktop,1000px&amp;mobileUI=1&amp;mobileUI.theme=none"></script>
	<style type="text/css">
		.cred {
			color: #ff0000;
		}
	</style>
	<!--[if IE 9]><link rel="stylesheet" href="css/style-ie9.css" /><![endif]-->
</head><body>
	<div id="wrapper">
		<?php
		include("header.php");
		;?>
		<div id="page-wrapper" class="5grid-layout">
			<div class="5grid-layout">
				<div class="row">
					<div class="6u">
						<div id="content">
							<section>
								<div>
									<h1 style="font-size: 24px">Danh mục tài liệu theo chủ đề <span style="color: #765ec9;"><?php echo $ten_chu_de ?></span></h1>
									<div>
										<ul>
											<?php
											$sql = "
											SELECT *
											FROM tai_lieu
											WHERE id_chu_de = $id_chu_de
											LIMIT 10											
											";
											$tai_lieu = mysqli_query($conn, $sql);
											while ($row = mysqli_fetch_array($tai_lieu)) {
												$id_tai_lieu = $row["id_tai_lieu"];
												;?>
												<li style="padding: 10px; line-height: 40px;"><h3 style="font-size: 18px; color: #0053f9;"><a style = "text-decoration: none; padding: 5px;" href="chi_tiet.php?id= <?php echo $id_tai_lieu ?>"><?php echo $row["tieu_de"];?></a></h3>
													<ul>																								
														<?php														
														$sql2 = "
														SELECT *
														FROM tai_lieu
														WHERE id_tai_lieu = $id_tai_lieu
														";
														$infoTaiLieu = mysqli_query($conn, $sql2);
														while ($row = mysqli_fetch_array($infoTaiLieu)) {
															;?>
															<li>
																<div style="float: left; width: 125px; height: 125px;"><img src="./images/covers/<?php 
																if ($row["anh_tai_lieu"]<>"") {
																	echo $row["anh_tai_lieu"];
																	} else {
																		echo "no_image.png";
																	}
																	;?>" width="105px" height="105px">
																</div>
																<div class="contextcate" style="width:590px;">
																	<p class="desc"><?php echo $row["mo_ta"] ?></p>
																	<p>
																		<img src="images/<?php echo $row["ma_dinh_dang"] ?>16x16.gif" alt="pdf">
																		<span class="cred"><?php echo $row["so_trang"] ?>p</span>
																		<span class="plr_5"></span>
																		<img src="images/iconshare13x10.png">
																		<span class="cred"><?php echo $row["nguoi_chia_se"] ?></span>
																		<span class="plr_5"></span>
																		<img src="images/icondate12x12.png">
																		<span class="cred"><?php echo $row["ngay_dang"] ?></span>
																		<span class="plr_5"></span>
																		<img src="images/icoview13x8.png">
																		<span class="cred"><?php echo $row["so_luot_xem"] ?></span>
																		<span class="plr_5"></span>
																		<img src="images/icodown7x9.png">
																		<span class="cred"><?php echo $row["so_luot_tai"] ?></span>
																	</p>
																</div>
															</li>
															<?php
														}
														;?>
													</ul>														
												</li>
												<?php
											}
											;?>
										</ul>
									</div>
								</div>
							</section>
							<section>
							</section>
						</div>
					</div>
					<div class="3u" id="sidebar1">
						<section>
						</section>
						<section>
						</section>
					</div>
					<div class="3u">
						<div id="sidebar2">
							<section>
								<div class="sbox1">
								</div>
								<div class="sbox2">
								</div>
							</section>
						</div>
					</div>
				</div>
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