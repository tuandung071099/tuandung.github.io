<?php
// 1. Chuỗi kết nối đến CSDL
$ket_noi = mysqli_connect("remotemysql.com:3306", "MFjxl5C769", "4yl0CnAF1W", "MFjxl5C769");

// 2. Lấy ra lấy dữ liệu thu được từ FORM chuyển sang
$tai_khoan = $_POST["txtTaiKhoan"];
$mat_khau = $_POST["txtMatKhau"];

// 3. Viết câu lệnh SQL để thêm mới tin tức vào CSDL
$sql = "
		SELECT * 
		FROM nguoi_dung
		WHERE ten_dang_nhap='" . $tai_khoan . "' AND mat_khau = '" . $mat_khau . "'
	";

// 4. Thực hiện truy vấn để thêm mới tức trên
$kqdangnhap = mysqli_query($ket_noi, $sql);
$sobanghi = mysqli_num_rows($kqdangnhap);
// var_dump($kqdangnhap); exit();

//5.  Điều hướng người đăng nhập hệ thống
if ($sobanghi == 0) {
	echo
		"
			<script type='text/javascript'>
				window.alert('Bạn đăng nhập không thành công.');
			</script>
		";

	// Chuyển người dùng vào trang quản trị tin tức
	echo
		"
			<script type='text/javascript'>
				window.location.href = './dang_nhap.php'
			</script>
		";
} else {
	session_start();

	// $_SESSION['email'] = $email;
	// $_SESSION['quyen_han'] = '1';

	echo
		"
			<script type='text/javascript'>
				window.alert('Bạn đã đăng nhập hệ thống thành công.');
			</script>
		";

	// Chuyển người dùng vào trang quản trị tin tức
	echo
		"
			<script type='text/javascript'>
				window.location.href = './dashboard.php'
			</script>
		";
}
