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
	$id_chu_de=$_GET["id"];
	$id2 = $_GET["id2"];	
	if($id_chu_de <> "") :
		$getChuDe = "
		SELECT *
		FROM chu_de
		WHERE id_chu_de='".$id_chu_de."'
		";
		$chuDeQuerry = mysqli_query($conn, $getChuDe);
		while ($row = mysqli_fetch_array($chuDeQuerry)) {
			$ten_chu_de = $row["ten_chu_de"];
			$id_the_loai = $row["id_loai_tai_lieu"];
			$mo_ta = $row["mo_ta"];
		};
		$ten = $ten_chu_de;
	else:
		$getChuDe = "
		SELECT *
		FROM chu_de Inner join loai_tai_lieu on chu_de.id_loai_tai_lieu = loai_tai_lieu.id_loai_tai_lieu
		WHERE chu_de.id_loai_tai_lieu='".$id2."'
		";
		$chuDeQuerry = mysqli_query($conn, $getChuDe);
		while ($row = mysqli_fetch_array($chuDeQuerry)) {
			$ten_loai_tai_lieu = $row["ten_loai_tai_lieu"];
			$id_the_loai = $row["id_loai_tai_lieu"];
			$mo_ta = $row["mo_ta"];
		};
		$ten = $ten_loai_tai_lieu;
	endif;	
	?>
	<title>Danh mục tài liệu theo chủ đề <?php echo $ten ?></title>
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
					<div class="3u" id="sidebar1">
						<section>
							<h2>Danh mục chủ đề</h2>
							<ul class="danhMuc">									
								<?php
								$getTheLoai = "
								SELECT * 
								FROM loai_tai_lieu chu_de Inner join loai_tai_lieu on chu_de.id_loai_tai_lieu = loai_tai_lieu.id_loai_tai_lieu
								";
								$theLoai = mysqli_query($conn, $getTheLoai);
								while ($row = mysqli_fetch_array($theLoai)) {
									;?>
									<li>
										<p>
											<span style="float: left;">
												<img src="images/ico_tailieu/<?php echo $row["id_loai_tai_lieu"] ?>.png">
											</span>
											<a href="chu_de.php?id=&id2=<?php echo $row["id_loai_tai_lieu"]?>">								
												<?php echo $row["ten_loai_tai_lieu"];?>
											</a>
										</p>
										<?php if($id_the_loai == $row["id_loai_tai_lieu"]) : ?>											
											<ul class = "danhMuc">
												<?php
												echo '<script type="text/javascript">
												$( "ul" )
												.closest( "li" )
												.css( "background-color", "#d0dde8" );
												</script>';
												$sql2 = "
												SELECT *
												FROM chu_de Inner join loai_tai_lieu on chu_de.id_loai_tai_lieu = loai_tai_lieu.id_loai_tai_lieu
												WHERE chu_de.id_loai_tai_lieu = $id_the_loai
												";
												$dsChuDe = mysqli_query($conn, $sql2);
												while ($row = mysqli_fetch_array($dsChuDe)) {
													;?>
													<div>
														<li class ="toActive1" style="padding-top: 5px;">
															<a href="chu_de.php?id=<?php echo $row["id_chu_de"]?>&id2=<?php echo $row["id_loai_tai_lieu"]?>">
																<?php echo $row["ten_chu_de"];?>																	
															</a>
															<?php
															if($id_chu_de == $row["id_chu_de"]) :
																echo '<script type="text/javascript">
																$( "a" )
																.closest( "li.toActive1" )
																.css( "background-color", "#b7bbea" );
																</script>';
															endif;
															?>
														</li>
													</div>
													<?php
												}
												;?>
											</ul>
										<?php endif; ?>
									</li>
									<?php
								}
								;?>
							</ul>
						</section>
					</div>
					<div class="8u">
						<div id="content">
							<section>
								<div>
									<h1 style="font-size: 24px">Danh mục tài liệu theo chủ đề <span style="color: #765ec9;"><?php echo $ten ?></span></h1>
									<p style="padding-top: 10px; text-align: justify;"><?php echo $mo_ta ?></p>
									<div>
										<ul>
											<?php
											if($id_chu_de <> "") :
												$sql = "
												SELECT *
												FROM tai_lieu
												WHERE id_chu_de = $id_chu_de
												LIMIT 10											
												";
												$chuDeQuerry = mysqli_query($conn, $getChuDe);
												while ($row = mysqli_fetch_array($chuDeQuerry)) {
													$ten_chu_de = $row["ten_chu_de"];
													$id_the_loai = $row["id_loai_tai_lieu"];
												};
												$ten = $ten_chu_de;
											else:
												$sql = "
												SELECT *
												FROM tai_lieu t
												INNER JOIN chu_de c ON t.id_chu_de = c.id_chu_de
												INNER JOIN loai_tai_lieu l ON c.id_loai_tai_lieu = l.id_loai_tai_lieu
												WHERE l.id_loai_tai_lieu = $id2
												";
												$chuDeQuerry = mysqli_query($conn, $getChuDe);
												while ($row = mysqli_fetch_array($chuDeQuerry)) {
													$ten_loai_tai_lieu = $row["ten_loai_tai_lieu"];
													$id_the_loai = $row["id_loai_tai_lieu"];
												};
												$ten = $ten_loai_tai_lieu;
											endif;											
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