<!DOCTYPE HTML>
<!--
	Affinity by TEMPLATED
	templated.co @templatedco
	Released for free under the Creative Commons Attribution 3.0 license (templated.co/license)
-->
<html>
<head>
	<?php
	$ket_noi = mysqli_connect("remotemysql.com:3306", "MFjxl5C769", "4yl0CnAF1W", "MFjxl5C769");
	$id_tai_lieu=$_GET["id"];
	$getTitle = "
	SELECT *
	FROM tai_lieu
	WHERE id_tai_lieu='".$id_tai_lieu."'
	";							
	$titleQuerry = mysqli_query($ket_noi, $getTitle);
	while ($row = mysqli_fetch_array($titleQuerry)) {
		$title = $row["tieu_de"];
	};
	?>
	<title><?php echo $title ?></title>
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
		<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
	</noscript>
	<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script>
	<script src="css/5grid/init.js?use=mobile,desktop,1000px&amp;mobileUI=1&amp;mobileUI.theme=none&amp;mobileUI.openerWidth=52"></script>

	<style>
		.btn {
			background-color: DodgerBlue;
			border: none;
			color: white;
			padding: 12px 30px;
			cursor: pointer;
			font-size: 20px;		}

			/* Darker background on mouse-over */
			.btn:hover {
				background-color: RoyalBlue;
			}
		</style>
		<!--[if IE 9]><link rel="stylesheet" href="css/style-ie9.css" /><![endif]-->
	</head><body>
		<div id="wrapper">
			<?php
			include("header.php");
			;?>
			<div id="page-wrapper" class="5grid-layout">
				<div class="row">
					<!-- BẮT ĐẦU CONTENT -->
					<div class="9u col-lg-9">
						<div id="content">
							<?php						
							$sql = "
							SELECT *
							FROM tai_lieu
							INNER JOIN nguoi_dung ON tai_lieu.id_nguoi_dung=nguoi_dung.id_nguoi_dung
							WHERE id_tai_lieu='".$id_tai_lieu."'
							";						
							$noi_dung = mysqli_query($ket_noi, $sql);										
							$view = "
							UPDATE tai_lieu SET so_luot_xem = so_luot_xem + 1 WHERE id_tai_lieu = $id_tai_lieu
							";
							mysqli_query($ket_noi, $view);													
							while ($row = mysqli_fetch_array($noi_dung)) {
								$chu_de = $row["id_chu_de"];
								$file = $row["file"];
								$description = $row["mo_ta"];
								$chia_se = $row["nguoi_chia_se"];
								$ngay = $row["ngay_dang"];
								$ngay = date("d/m/y");
								$dinh_dang = $row["ma_dinh_dang"];
								$so_luot_xem = $row["so_luot_xem"];
								$so_luot_tai = $row["so_luot_tai"];
								$so_trang = $row["so_trang"];
								;?>
								<div>
									<p>
										<?php
										$source = mysqli_query($ket_noi, "SELECT * FROM chu_de INNER JOIN loai_tai_lieu WHERE chu_de.id_loai_tai_lieu = loai_tai_lieu.id_loai_tai_lieu AND chu_de.id_chu_de = $chu_de");
										while ($run = mysqli_fetch_array($source)) {
											$ten_chu_de = $run["ten_chu_de"];
											$ten_loai_tai_lieu = $run["ten_loai_tai_lieu"];
											$id_loai_tai_lieu = $run["id_loai_tai_lieu"];
										}
										?>
										<a href="index.php">Trang chủ</a> >> 
										<a href="chu_de.php?id=<?php echo $id_loai_tai_lieu ?>"><?php echo $ten_loai_tai_lieu ?></a> >>
										<a href="chu_de.php?id=<?php echo $chu_de ?>"><?php echo $ten_chu_de ?></a>
									</p>
								</div>
								<h1 style="color: #765ec9; font-size: 24px"><?php echo $row["tieu_de"];?></h1>
								<div style="width:130px;float:right; text-align:center;font-weight: 400; padding: 10px;">
									<span style="float: left; padding-right: 20px">
										<span style="font-size: 16px; color: #f10000;"><?php echo $so_luot_xem;?></span>
										<br><span style="font-size: 12px;">lượt xem</span>
									</span>
									<span style="float: left;">
										<span style="font-size: 16px; color: #f10000;"><?php echo $so_luot_tai;?></span>
										<br><span style="font-size: 12px;">download</span>
									</span>
								</div>
								<p style="font-size: 11px">Chia sẻ: <span style="color: #f10000"><?php echo $chia_se;?></span>
									| Ngày: <span style="color: #f10000"><?php echo $ngay;?></span>
									| Loại File: <span style="color: #f10000"><?php echo $dinh_dang;?></span>
									| Số trang:<span style="color: #f10000"><?php echo $so_trang;?></span>
								</p>
								<iframe src="./pdf/<?php echo $file;?>" width="870px" height="500px"></iframe>					
								<!-- BẮT ĐẦU BÊN DƯỚI PDF -->
								<div style=" float: left; width: 650px; height: 310px; margin-top:20px">
									<div style="float: left; width: 125px; height: 125px;"><img src="./images/covers/<?php 
									if ($row["anh_tai_lieu"]<>"") {
										echo $row["anh_tai_lieu"];
										} else {
											echo "no_image.png";
										}
										;?>" width="105px" height="105px">
									</div>
									<div style="float: left;width: 500px; height: 125px;margin-left:10px">
										<h1 style="color: #765ec9;"><?php echo $title;?></h1>
									</div>
									<div style="float: left;width: 650px; height: 125px;">
										<p>Mô tả tài liệu:</p>
										<p><?php echo $description ?></p>
									</div>
								</div>
								<div style="float: left;width: 150px;height: 310px; margin-top:20px;margin-left:20px; float: right;">
									<a href="download_thuc_hien.php?id=<?php echo $id_tai_lieu;?>">
										<img src="images/Download-Button-Transparent.png" style="width: 150px"><p style="width:160px;font-size:14px;float:left;text-align:center;">Vui lòng tải xuống để xem tài liệu đầy đủ</p>
									</a>
								</div>
								<?php
							}
							;?>	
							<!-- KẾT THÚC BÊN DƯỚI PDF -->
						</div>
					</div>
					<!-- KẾT THÚC CONTENT -->

					<!-- BẮT ĐẦU SIDEBAR -->
					<div class="3u col-lg-3">
						<div id="sidebar2">
							<section>
								<div class="sbox1">
									<h2>Cùng thể loại</h2>
									<ul class="style1">
										<?php
										$the_loai = "
										SELECT *
										FROM tai_lieu t
										INNER JOIN chu_de c ON t.id_chu_de = c.id_chu_de
										INNER JOIN loai_tai_lieu l ON c.id_loai_tai_lieu = l.id_loai_tai_lieu
										WHERE l.id_loai_tai_lieu = $id_loai_tai_lieu AND id_tai_lieu <> $id_tai_lieu
										ORDER BY so_luot_xem + so_luot_tai desc
										LIMIT 7	
										";
										$khcn = mysqli_query($ket_noi, $the_loai);
										while ($row = mysqli_fetch_array($khcn)) {
											;?>
											<li><a href="chi_tiet.php?id=<?php echo $row["id_tai_lieu"];?>">
												<?php echo $row["tieu_de"];?>
												<p class="f10">
													<img src="images/<?php echo $row["ma_dinh_dang"] ?>16x16.gif" alt="pdf">
													<span class="cred"><?php echo $row["so_trang"] ?>p</span> | 
													<img src="images/icoview13x8.png">
													<span class="cred"><?php echo $row["so_luot_xem"] ?></span> | 
													<img src="images/icodown7x9.png">
													<span class="cred"><?php echo $row["so_luot_tai"] ?></span>
												</p>
											</a></li>
											<?php
										}
										;?>
									</ul>
								</div>
								<div class="sbox2">
									<h2>Cùng chủ đề</h2>
									<ul class="style1">
										<?php
										$chuDe = "
										SELECT *
										FROM tai_lieu
										WHERE id_chu_de = $chu_de AND id_tai_lieu <> $id_tai_lieu
										ORDER BY so_luot_xem + so_luot_tai desc
										LIMIT 7
										";
										$tlCD = mysqli_query($ket_noi, $chuDe);
										while ($row = mysqli_fetch_array($tlCD)) {
											;?>
											<li><a href="chi_tiet.php?id=<?php echo $row["id_tai_lieu"];?>">
												<?php echo $row["tieu_de"];?>
												<p class="f10">
													<img src="images/<?php echo $row["ma_dinh_dang"] ?>16x16.gif" alt="pdf">
													<span class="cred"><?php echo $row["so_trang"] ?>p</span> | 
													<img src="images/icoview13x8.png">
													<span class="cred"><?php echo $row["so_luot_xem"] ?></span> | 
													<img src="images/icodown7x9.png">
													<span class="cred"><?php echo $row["so_luot_tai"] ?></span>
												</p>
											</a></li>
											<?php
										}
										;?>
									</ul>
								</div>
							</section>
						</div>						
					</div>
				</div>
				<!-- KẾT THÚC SIDEBAR -->
			</div>
		</div>
		<?php
			include("footer.php");
		;?>
</body>
</html>