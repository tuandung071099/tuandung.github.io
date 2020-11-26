<!DOCTYPE HTML>

<html>

<head>
	<title>Read so much</title>
	<meta http-equiv="content-type" content="text/html; charset=utf-8" />
	<meta name="description" content="" />
	<meta name="keywords" content="" />
	<link rel="icon" href="images/fav.ico">
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
	<!--[if IE 9]><link rel="stylesheet" href="css/style-ie9.css" /><![endif]-->
	<style>
		* {
			box-sizing: border-box
		}

		body {
			font-family: Arial, Helvetica, sans-serif;
			margin: 0
		}

		.mySlides {
			display: none
		}

		img {
			vertical-align: middle;
		}

		/* Slideshow container */
		.slideshow-container {
			max-width: 1200px;
			position: relative;
			margin: auto;
			padding-top: 1px;
		}

		/* Next & previous buttons */
		.prev,
		.next {
			cursor: pointer;
			position: absolute;
			top: 50%;
			width: auto;
			padding: 16px;
			margin-top: -22px;
			color: white;
			font-weight: bold;
			font-size: 18px;
			transition: 0.6s ease;
			border-radius: 0 3px 3px 0;
			user-select: none;
		}

		/* Position the "next button" to the right */
		.next {
			right: 0;
			border-radius: 3px 0 0 3px;
		}

		/* On hover, add a black background color with a little bit see-through */
		.prev:hover,
		.next:hover {
			background-color: rgba(0, 0, 0, 0.8);
		}

		/* Caption text */
		.text {
			color: #f2f2f2;
			font-size: 15px;
			padding: 8px 12px;
			position: absolute;
			bottom: 8px;
			width: 100%;
			text-align: center;
		}

		/* Number text (1/3 etc) */
		.numbertext {
			color: #f2f2f2;
			font-size: 12px;
			padding: 8px 12px;
			position: absolute;
			top: 0;
		}

		/* The dots/bullets/indicators */
		.dot {
			cursor: pointer;
			height: 15px;
			width: 15px;
			margin: 0 2px;
			background-color: #bbb;
			border-radius: 50%;
			display: inline-block;
			transition: background-color 0.6s ease;
		}

		.active,
		.dot:hover {
			background-color: #717171;
		}

		/* Fading animation */
		.fade {
			-webkit-animation-name: fade;
			-webkit-animation-duration: 1.5s;
			animation-name: fade;
			animation-duration: 1.5s;
		}

		@-webkit-keyframes fade {
			from {
				opacity: .4
			}

			to {
				opacity: 1
			}
		}

		@keyframes fade {
			from {
				opacity: .4
			}

			to {
				opacity: 1
			}
		}

		/* On smaller screens, decrease text size */
		@media only screen and (max-width: 300px) {

			.prev,
			.next,
			.text {
				font-size: 11px
			}
		}
	</style>
</head>

<body>
	<div id="wrapper">
		<?php
		$conn = mysqli_connect("remotemysql.com:3306", "MFjxl5C769", "4yl0CnAF1W", "MFjxl5C769");; ?>
		<?php
		include("header.php");; ?>
		<div id="page-wrapper" class="5grid-layout">
			<!-- Slideshow container -->
			<div class="slideshow-container">
				<!-- Full-width images with number and caption text -->
				<div class="mySlides fade">
					<div class="numbertext">1 / 3</div>
					<img src="./images/book-1000x350.jpg" style="width:100%; margin-top:-31px">
					<div class="text"></div>
				</div>

				<div class="mySlides fade">
					<div class="numbertext">2 / 3</div>
					<img src="./images/study-1000x350.jpg" style="width:100%; margin-top:-31px">
					<div class="text"></div>
				</div>

				<div class="mySlides fade">
					<div class="numbertext">3 / 3</div>
					<img src="./images/LondonLibrary-1000x350.jpg" style="width:100%; margin-top:-31px">
					<div class="text"></div>
				</div>

				<!-- Next and previous buttons -->
				<a class="prev" onclick="plusSlides(-1)">&#10094;</a>
				<a class="next" onclick="plusSlides(1)">&#10095;</a>
			</div>
			<br>

			<!-- The dots/circles -->
			<div style="text-align:center">
				<span class="dot" onclick="currentSlide(1)"></span>
				<span class="dot" onclick="currentSlide(2)"></span>
				<span class="dot" onclick="currentSlide(3)"></span>
			</div>
			<script>
				var slideIndex = 1;
				showSlides(slideIndex);

				// Next/previous controls
				function plusSlides(n) {
					showSlides(slideIndex += n);
				}

				// Thumbnail image controls
				function currentSlide(n) {
					showSlides(slideIndex = n);
				}

				function showSlides(n) {
					var i;
					var slides = document.getElementsByClassName("mySlides");
					var dots = document.getElementsByClassName("dot");
					if (n > slides.length) {
						slideIndex = 1
					}
					if (n < 1) {
						slideIndex = slides.length
					}
					for (i = 0; i < slides.length; i++) {
						slides[i].style.display = "none";
					}
					for (i = 0; i < dots.length; i++) {
						dots[i].className = dots[i].className.replace(" active", "");
					}
					slides[slideIndex - 1].style.display = "block";
					dots[slideIndex - 1].className += " active";
				}
			</script>
			<div class="5grid-layout">
				<div class="row">
					<div class="6u">
						<div id="content">
							<h2 style="color: #FF3F00;">Tài liệu được xem nhiều</h2>
							<ul>
								<?php
								$sql = "
												SELECT *
												FROM tai_lieu
												ORDER BY so_luot_tai + so_luot_xem desc
												LIMIT 3											
												";
								$tai_lieu = mysqli_query($conn, $sql);
								while ($row = mysqli_fetch_array($tai_lieu)) {
									$id_tai_lieu = $row["id_tai_lieu"];; ?>
									<li style="padding: 10px; line-height: 40px;">
										<h3 style="font-size: 18px; color: #0053f9;"><a style="text-decoration: none; padding: 5px;" href="chi_tiet.php?id= <?php echo $id_tai_lieu ?>"><?php echo $row["tieu_de"]; ?></a></h3>
										<ul>
											<?php
											$sql2 = "
														SELECT *
														FROM tai_lieu
														WHERE id_tai_lieu = $id_tai_lieu
														";
											$infoTaiLieu = mysqli_query($conn, $sql2);
											while ($row = mysqli_fetch_array($infoTaiLieu)) {
												$date = $row["ngay_dang"];
												$date = date("d/m/y");; ?>
												<li>
													<div style="float: left; width: 125px; height: 125px;"><img src="./images/covers/<?php
																																		if ($row["anh_tai_lieu"] <> "") {
																																			echo $row["anh_tai_lieu"];
																																		} else {
																																			echo "no_image.png";
																																		}; ?>" width="105px" height="105px">
													</div>
													<div class="contextcate" style="">
														<p class="desc" style="max-height: 105px; overflow: auto; text-align: justify;"><?php echo $row["mo_ta"] ?></p>
														<p>
															<img src="images/<?php echo $row["ma_dinh_dang"] ?>16x16.gif" alt="pdf">
															<span class="cred"><?php echo $row["so_trang"] ?>p</span>
															<img src="images/iconshare13x10.png">
															<span class="cred"><?php echo $row["nguoi_chia_se"] ?></span>
															<img src="images/icondate12x12.png">
															<span class="cred"><?php echo $date ?></span>
															<img src="images/icoview13x8.png">
															<span class="cred"><?php echo $row["so_luot_xem"] ?></span>
															<img src="images/icodown7x9.png">
															<span class="cred"><?php echo $row["so_luot_tai"] ?></span>
														</p>
													</div>
												</li>
											<?php
											}; ?>
										</ul>
									</li>
								<?php
								}; ?>
							</ul>
							<h2 style="color: #FF3F00;">Tài liệu mới</h2>
							<ul>
								<?php
								$sql = "
												SELECT *
												FROM tai_lieu
												ORDER BY  id_tai_lieu
												desc
												LIMIT 3											
												";
								$tai_lieu = mysqli_query($conn, $sql);
								while ($row = mysqli_fetch_array($tai_lieu)) {
									$id_tai_lieu = $row["id_tai_lieu"];; ?>
									<li style="padding: 10px; line-height: 40px;">
										<h3 style="font-size: 18px; color: #0053f9;"><a style="text-decoration: none; padding: 5px;" href="chi_tiet.php?id= <?php echo $id_tai_lieu ?>"><?php echo $row["tieu_de"]; ?></a></h3>
										<ul>
											<?php
											$sql2 = "
														SELECT *
														FROM tai_lieu
														WHERE id_tai_lieu = $id_tai_lieu
														";
											$infoTaiLieu = mysqli_query($conn, $sql2);
											while ($row = mysqli_fetch_array($infoTaiLieu)) {
												$date = $row["ngay_dang"];
												$date = date("d/m/y");; ?>
												<li>
													<div style="float: left; width: 125px; height: 125px;"><img src="./images/covers/<?php
																																		if ($row["anh_tai_lieu"] <> "") {
																																			echo $row["anh_tai_lieu"];
																																		} else {
																																			echo "no_image.png";
																																		}; ?>" width="105px" height="105px">
													</div>
													<div class="contextcate" style="">
														<p class="desc" style="max-height: 105px; overflow: auto; text-align: justify;"><?php echo $row["mo_ta"] ?></p>
														<p>
															<img src="images/<?php echo $row["ma_dinh_dang"] ?>16x16.gif" alt="pdf">
															<span class="cred"><?php echo $row["so_trang"] ?>p</span>
															<img src="images/iconshare13x10.png">
															<span class="cred"><?php echo $row["nguoi_chia_se"] ?></span>
															<img src="images/icondate12x12.png">
															<span class="cred"><?php echo $date ?></span>
															<img src="images/icoview13x8.png">
															<span class="cred"><?php echo $row["so_luot_xem"] ?></span>
															<img src="images/icodown7x9.png">
															<span class="cred"><?php echo $row["so_luot_tai"] ?></span>
														</p>
													</div>
												</li>
											<?php
											}; ?>
										</ul>
									</li>
								<?php
								}; ?>
							</ul>
						</div>
						
					</div>
					<div class="3u" id="sidebar1">
						<section>
							<h2>Kinh Doanh Marketing</h2>
							<ul class="style1">
								<?php
								$sql = "
									SELECT *
									FROM tai_lieu
									INNER JOIN chu_de ON tai_lieu.id_chu_de = chu_de.id_chu_de
									WHERE id_loai_tai_lieu = 6
									ORDER BY so_luot_tai + so_luot_xem desc
									LIMIT 7	
									";
								$gddt = mysqli_query($conn, $sql);
								while ($row = mysqli_fetch_array($gddt)) {; ?>
									<li><a href="chi_tiet.php?id=<?php echo $row["id_tai_lieu"]; ?>">
											<?php echo $row["tieu_de"]; ?>
										</a></li>
								<?php
								}; ?>
							</ul>
						</section>
						<section>
							<h2>Kinh Tế - Quản Lý</h2>
							<ul class="style1">
								<?php
								$sql = "
									SELECT *
									FROM tai_lieu
									INNER JOIN chu_de ON tai_lieu.id_chu_de = chu_de.id_chu_de
									WHERE id_loai_tai_lieu = 7
									ORDER BY so_luot_tai + so_luot_xem desc
									LIMIT 7	
									";
								$nn = mysqli_query($conn, $sql);
								while ($row = mysqli_fetch_array($nn)) {; ?>
									<li><a href="chi_tiet.php?id=<?php echo $row["id_tai_lieu"]; ?>">
											<?php echo $row["tieu_de"]; ?>
										</a></li>
								<?php
								}; ?>
							</ul>
						</section>
					</div>
					<div class="3u">
						<div id="sidebar2">
							<section>
								<div class="sbox1">
									<h2>Biểu Mẫu - Văn Bản</h2>
									<ul class="style1">
										<?php
										$sql = "
											SELECT *
											FROM tai_lieu
											INNER JOIN chu_de ON tai_lieu.id_chu_de = chu_de.id_chu_de
											WHERE id_loai_tai_lieu = 8
											ORDER BY so_luot_tai + so_luot_xem desc
											LIMIT 7	
											";
										$khcn = mysqli_query($conn, $sql);
										while ($row = mysqli_fetch_array($khcn)) {; ?>
											<li><a href="chi_tiet.php?id=<?php echo $row["id_tai_lieu"]; ?>">
													<?php echo $row["tieu_de"]; ?>
												</a></li>
										<?php
										}; ?>
									</ul>
								</div>
								<div class="sbox2">
									<h2>Tài Chính - Ngân Hàng</h2>
									<ul class="style1">
										<?php
										$sql = "
											SELECT *
											FROM tai_lieu
											INNER JOIN chu_de ON tai_lieu.id_chu_de = chu_de.id_chu_de
											WHERE id_loai_tai_lieu = 9
											ORDER BY so_luot_tai + so_luot_xem desc
											LIMIT 7	
											";
										$ktql = mysqli_query($conn, $sql);
										while ($row = mysqli_fetch_array($ktql)) {; ?>
											<li><a href="chi_tiet.php?id=<?php echo $row["id_tai_lieu"]; ?>">
													<?php echo $row["tieu_de"]; ?>
												</a></li>
										<?php
										}; ?>
									</ul>
								</div>
							</section>
						</div>
					</div>
				</div>
			</div>
		</div>
		<?php
		include("footerindex.php");; ?>
</body>

</html>