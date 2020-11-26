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
	$str='"%'. $_GET["search"] .'%"';
	$search = "
	SELECT *
	FROM tai_lieu t
	INNER JOIN chu_de c ON t.id_chu_de = c.id_chu_de
	INNER JOIN loai_tai_lieu l ON c.id_loai_tai_lieu = l.id_loai_tai_lieu
	WHERE tieu_de LIKE ".$str."
	OR ten_loai_tai_lieu LIKE ".$str."
	OR ten_chu_de LIKE ".$str."
	";
	?>
	<title>Read So Much - Tìm kiếm tài liệu</title>
	<meta http-equiv="content-type" content="text/html; charset=utf-8" />
	<meta name="description" content="" />
	<link rel="icon" href="images/fav.ico">
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
					<div class="12u">
						<div id="content">
							<section>
								<div>
									<h1 style="font-size: 24px">
										Tìm kiếm tài liệu theo từ khóa 
										<span style="color: #765ec9;">
											<?php echo '"'.$_GET["search"].'"' ?>
										</span>
									</h1>
									<div>
										<ul>
											<?php
											$i = 0;														
											$searchQuerry = mysqli_query($conn, $search);
											while ($row = mysqli_fetch_array($searchQuerry)) {
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
															$date = $row["ngay_dang"];
															$date = date("d/m/y");
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
				</div>
			</div>
		</div>
		<?php
		include("footer.php");
		;?>
	</body>
	</html>