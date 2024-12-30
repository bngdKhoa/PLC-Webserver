<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TraCuu.aspx.cs" Inherits="Default2" %>

<%@ Register Assembly="AjaxControlToolkit" 
    Namespace="AjaxControlToolkit" TagPrefix="asp" %> <%--gọi thư viện AjaxToolkit--%>

<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>--%>

<!DOCTYPE html>
<html>
<head>
    <title>HỆ THỐNG</title>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Montserrat">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <style>
        body, h1, h2, h3, h4, h5, h6 {
            font-family: "Montserrat", sans-serif
        }

        .w3-row-padding img {
            margin-bottom: 12px
        }
        /* Set the width of the sidebar to 120px */
        .w3-sidebar {
            width: 120px;
            background: #222;
        }
        /* Add a left margin to the "page content" that matches the width of the sidebar (120px) */
        #main {
            margin-left: 120px
        }
        /* Remove margins from "page content" on small screens */
        @media only screen and (max-width: 600px) {
            #main {
                margin-left: 0
            }
        }
    </style>
</head>

 <style>

table {
  font-family: arial, sans-serif;
  border-collapse: collapse;
  width: 100%;
}

td, th {
  border: 1px solid #dddddd;
  text-align: center;
  padding: 8px;
  /*max-width: 1000px;*/  /* Đặt chiều rộng tối đa cho bảng là 1000px */
  /*margin-left: auto;*/ /* Căn giữa bảng theo chiều ngang */
  /*margin-right: auto;*/ /* Căn giữa bảng theo chiều ngang */
}


table tbody tr:nth-child(even) {
  background-color: #f9f9f9;
}

table tbody tr:hover {
  background-color: #eaeaea;
}

table td {
  vertical-align: middle;
}

table .center {
  text-align: center;
}

table .right {
  text-align: right;
}

table .bold {
  font-weight: bold;
}

table .index {
  width: 20px;
  text-align: center;
}
h2 {
    text-align: center;
    color: blue;
  }

.centered-text {
    text-align: center;
    font-weight: bold;
    color: red;
    font-size: 24px;
}
</style>
<body class="w3-white">

        <!-- Icon Bar (Sidebar - hidden on small screens) -->
<nav class="w3-sidebar w3-bar-block w3-small w3-hide-small w3-center">
    <!-- Avatar image in top left corner -->
    <img src="/Image/Logo HCMUTE_Color background.png" style="width:100%">

    <a href="#" class="w3-bar-item w3-button w3-padding-large w3-hover-black" onclick="goHomePage()">
        <i class="fa fa-home w3-xxlarge"></i>
        <p>TRANG CHỦ</p>
    </a>

    <a href="#" class="w3-bar-item w3-button w3-padding-large w3-hover-black" onclick="goSenSorPage()">
        <i class="fa fa-eye w3-xxlarge"></i>
        <p>DỮ LIỆU CẢM BIẾN</p>
    </a>
    <a href="#" class="w3-bar-item w3-button w3-padding-large w3-black">
        <i class="fa fa-search w3-xxlarge"></i>
        <p>TRA CỨU CẢM BIẾN</p>
    </a>

    <a href="#" class="w3-bar-item w3-button w3-padding-large w3-hover-black" onclick="showPasswordPrompt()">
        <i class="fa fa-file w3-xxlarge"></i>
        <p>DỮ LIỆU MỚI NHẤT</p>
    </a>

    <a href="#" class="w3-bar-item w3-button w3-padding-large w3-hover-black" onclick="goTrangchu()">
        <i class="fa fa-arrow-left w3-xxlarge"></i>
        <p>ĐĂNG XUẤT</p>
    </a>
</nav>

<!-- Navbar on small screens (Hidden on medium and large screens) -->
<div class="w3-top w3-hide-large w3-hide-medium" id="myNavbar">
    <div class="w3-bar w3-black w3-opacity w3-hover-opacity-off w3-center w3-small">
        <a href="#" class="w3-bar-item w3-button" style="width:25% !important">HOME</a>
        <a href="#about" class="w3-bar-item w3-button" style="width:25% !important">ABOUT</a>
        <a href="#photos" class="w3-bar-item w3-button" style="width:25% !important">PHOTOS</a>
        <a href="#contact" class="w3-bar-item w3-button" style="width:25% !important">CONTACT</a>
    </div>
</div>

 <div id="passwordModal" class="w3-modal">
    <div class="w3-modal-content w3-card-4 w3-animate-zoom" style="max-width: 300px">
         <div class="w3-container w3-padding">
             <span id="passwordErrorMessage" class="w3-text-red"></span>
             <span onclick="document.getElementById('passwordModal').style.display='none'" class="w3-button w3-display-topright w3-hover-red" title="Đóng">&times;</span>
             <h3>Nhập mật khẩu</h3>
             <input type="password" id="passwordInput" placeholder="Nhập mật khẩu" class="w3-input w3-border">
             <button onclick="checkPassword()" class="w3-button w3-block w3-green w3-section w3-padding">Xác nhận</button>
             <button onclick="cancelPasswordInput()" class="w3-button w3-block w3-green w3-section w3-padding">Hủy</button>
         </div>
     </div>
 </div>

 <script>
         function goSenSorPage() {
             // Chuyển hướng đến trang Cảm biến 
             window.location.href = "Cambien.aspx";
         }
         function goLastestDataPage() {
                 // Chuyển hướng đến trang Dữ liệu mới nhất 
             window.location.href = "DuLieuOL.aspx";
         }

         function goHomePage() {
             // Chuyển hướng đến trang chủ
             window.location.href = "HtmlPage.html";
         }

        function goTrangchu() {
        // Chuyển hướng đến trang chủ
        window.location.href = "Trangchu.html";
         }

         function showPasswordPrompt() {
             // Hiển thị modal khi nhấn vào "Dữ liệu mới nhất"
             document.getElementById('passwordModal').style.display = 'block';
         }

         function checkPassword() {
             var password = document.getElementById('passwordInput').value;

             // Kiểm tra mật khẩu (có thể thay đổi mật khẩu mặc định ở đây)
             var correctPassword = "1234";

             if (password === correctPassword) {
                 // Nếu mật khẩu đúng, chuyển hướng đến trang "Dữ liệu mới nhất"
                 window.location.href = "DuLieuOL.aspx";
             } else {
                 document.getElementById('passwordErrorMessage').innerText = "Mật khẩu không chính xác. Vui lòng thử lại.";
             }

             // Đóng modal sau khi kiểm tra mật khẩu
             /*document.getElementById('passwordModal').style.display = 'none';*/
         }

         function cancelPasswordInput() {

             document.getElementById('passwordModal').style.display = 'none';// Đóng modal 
         }

 </script>

    <form id="form1" runat="server">

        <asp:ToolkitScriptManager ID="ToolkitScriptManager" runat="server">
        </asp:ToolkitScriptManager>

        <br /><div class="centered-text">
        <b>TRA CỨU GIÁ TRỊ CẢM BIẾN</b>
        </div><br />

        <div>
  
            <asp:UpdatePanel ID="UpdatePanel1" runat="server"> <%--cập nhật dữ liệu mà k phải load lại toàn bộ page--%>
                <ContentTemplate>

                <div style="display: flex; justify-content: center;">
                    <asp:TextBox ID="tbxSensorId" runat="server" style="width: 200px; height: 25px;"></asp:TextBox> <%--tạo textbox để nhập tên CB--%>
                    <asp:TextBox ID="tbxStarttime" runat="server" style="width: 200px; height: 25px;"></asp:TextBox> <%--tạo textbox để nhập starttime--%>
                    <asp:TextBox ID="tbxEndtime" runat="server" style="width: 200px; height: 25px;"></asp:TextBox> <%--tạo textbox để nhập endtime--%>
                    <asp:Button ID="btnXem" runat="server" style="width: 200px; height: 25px;" Text="Xem giá trị cảm biến" OnClick="btnXem_Click" />
                    <%--tạo nút nhấn để xem giá trị CB--%>
                </div>

                    <asp:Literal ID="Literal2" runat="server"></asp:Literal> <%--dùng để hiện thị dữ liệu từ code-behind--%>
                </ContentTemplate>
            </asp:UpdatePanel>


        </div>
    </form>
</body>
</html>
