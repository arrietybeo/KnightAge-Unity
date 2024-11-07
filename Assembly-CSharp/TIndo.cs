public class TIndo : T
{
	public TIndo()
	{
		T.tathieuung = "Efek: MATI";
		T.bathieuung = "Efek: HIDUP";
		T.khac = "Lain nya";
		T.bonguyenlieu = "Taruh 5 material dan akan aku upgrade untukmu.";
		T.hoprac = "Create";
		T.members = "Members: ";
		T.thanhcong = "Upgrade success";
		T.thatbai = "Upgrade fail";
		T.thoigianconlai = "Time ";
		T.mapName = new string[92]
		{
			"Desa Kecil",
			"Desa Serigala",
			"Tambang",
			"Tepi Hutan",
			"Gua Api",
			"Hutan Keramat",
			"Ngarai",
			"Padang Rumput Serigala",
			"Lembah Misterius",
			"Danau Keramat",
			"Zona Kosong",
			"Pesisir Pantai",
			"Tebing Batu",
			"Daerah Batu Karang",
			"Bangkai Kapal",
			"Rawa",
			"Kuil Kuna",
			"Gua Kelelawar",
			"Gua Siluman Serigala",
			"Pantai",
			"Gurun",
			"Bukit Pasir",
			"Zona Lembah",
			"Jurang Kematian",
			"Kuburan Pasir",
			"Hutan Kematian",
			"Pemandian Air Panas",
			"Lembah Batu",
			"Monster Penjaga",
			"Bangunan Bawah Tanah Tingkat 1",
			"Bangunan Bawah Tanah Tingkat 2",
			"Bangunan Bawah Tanah Tingkat 3",
			"Raja Mummi",
			"Kota Emas",
			"Sisi Barat",
			"Sisi Timur",
			"Arena",
			"Gunung Langit",
			"Jalur Pegunungan",
			"Tebing",
			"Gunung Pelangi",
			"Pintu Masuk Ke Dunia Atas",
			"Jalan Lembah",
			"Pintu Masuk Kebawah Tanah",
			"Tebing",
			"Pintu Masuk Dunia Bawah",
			"Arena",
			"Bukit Mayat",
			"Persimpangan Kematian",
			"Phó bản mới",
			"Kebun",
			"Gerbang Surga",
			"Gerbang Neraka",
			"Equip",
			"Desa Cahaya",
			"Equip",
			"Desa Angin",
			"Prepare",
			"Desa Halilintar",
			"Prepare",
			"Desa Api",
			"Medan Perang",
			"Neraka Lantai 1",
			"Hutan Medusa",
			"Hutan Angker",
			"Hutan Monster",
			"Air Terjun",
			"Kota Pelabuhan",
			"Area pantai selatan",
			"Area pantai utara",
			"Area pantai barat",
			"Hutan tikus",
			"Hutan bunga merah",
			"Teluk Caribe ",
			"Labirin",
			"Labirin Lantai 1",
			"Labirin Lantai 2",
			"Labirin Lantai 3",
			"Labirin Lantai 4",
			"Labirin Lantai Terakhir",
			"DUEL",
			string.Empty,
			"Buka Lapak",
			"Gerbang Timur",
			"Gerbang Barat",
			"Gerbang Selatan",
			"Gerbang Utara",
			"Arena",
			"Map 88",
			"Map 89",
			"Map 90",
			"Map 91"
		};
		T.hiennguoichoi = "Tampilkan pemain lain";
		T.hoihienguoichoi = "Apakah Anda ingin menunjukkan pemain lain";
		T.hoiannguoichoi = "Apakah Anda ingin menyembunyikan pemain lain";
		T.annguoichoi = "Sembunyikan pemain lain";
		T.trangbi1 = "Equipment 1";
		T.trangbi2 = "Equipment 2";
		T.quaylai = "return";
		T.can_not_move = "Hi mblo,kamu tidak dapat pindah ketika sedang berjualan.  Apakah kamu ingin lanjut berjualan?";
		T.nhapSlogan = "Masukan Nama Toko";
		T.hoanthanh = "Selesai";
		T.nhapsai = "Error bro.  Harap masukan kembali.";
		T.hoidaugia = "Kamu ingin menjual: ";
		T.nhapgiaban = "Masukan Harga";
		T.daugia = "Jual";
		T.gianHang = "Toko";
		T.NghiBan = "Berhenti Berjualan";
		T.TimeThachDau = "Tantangan dimulai setelah: ";
		T.chuaboduclo = "Mari kita pahat misteri dan item Anda, setelah itu saya akan pahat untuk Anda lubang";
		T.DucLo = "membuat lubang";
		T.muaNhieu = "membeli";
		T.bongoc = "Menempatkan permata, dan aku akan graft permata untuk Anda";
		T.hopngoc = "Mix Gem";
		T.hetNgoc = "Anda telah menjalankan keluar permata ini, mari kita pergi keluar dan membunuh monster untuk mengumpulkan permata dan membawa mereka kembali ke saya";
		T.khongbothem = "tidak dapat menambahkan lagi";
		T.chuaboitem = "Silakan memasukkan senjata Anda, saya akan mencampur permata untuk Anda";
		T.bovao = "Put in";
		T.khamNgoc = "Add gem";
		T.khongcongua = "Anda tidak memiliki gunung dalam persediaan";
		T.Logifail = "Hubungkan gagal, periksa koneksi internet Anda.";
		T.Tips = "Tips: ";
		T.mTips = new string[13]
		{
			"Tahan tombol chatting di 2s, itu akan membuka obrolan cepat menu.", "Kotak beruntung yang muncul secara acak setiap 1 jam di peta.", "Satu serikat dapat memiliki lebih dari satu tambang.", "Berburu monster dan tantangan ksatria lain akan mendapatkan ketenaran.", "Ketenaran akan menurun jika ksatria aktif untuk beberapa waktu.", "Penjara Lengkap bisa mendapatkan telur Pet.", "Register arena di Mr Ballard dalam neraka Cave.", "Boss akan terlahir kembali setelah 12 jam.", "Meningkatkan barang secara acak akan mendapatkan tulang.", "Ghost akan muncul setelah Ksatria mencapai level 20.",
			"Titik Kesehatan dapat dikembalikan ketika berdiri diam atau menggunakan makanan.", "Bisa bergabung Zone (2h) secara gratis dengan Tyche koin.", "Di Zona (2h), drop tarif dan pengalaman akan zona lainnya yang lebih tinggi."
		};
		T.mQuickChat = new string[20]
		{
			"Hai!", "muahahaha!!!", "Tunggu aku sebentar!", "Cupu!", "Pro!", "Terlalu lag!", "Partai?", "Semua orang mengumpulkan", "Ayo", "Mari kita menyerang saya!",
			"Mari berburu bos!", "Yang membunuh saya!", "Terlalu ramai!", "Apakah Anda ingin PK?", "Harap mengundang saya untuk serikat!", "Merekrut anggota!", "Pergi tidur", "Bye!", "berbahaya! menjalankan", "Tolong aku!"
		};
		T.TchangSv = "Login lagi.";
		T.TuseNgua = "Kuda";
		T.TisNguaNau = "tidak bisa menyerang kuda!";
		T.speedUp = "Mempercepat";
		T.infoArena = "Informasi Battlefield";
		T.backBattlefield = "Bergabunglah medan setelah: ";
		T.textXuongNgua = "Dari kuda";
		T.textHoiXuongNgua = "Kuda akan hilang bila dari kuda, Anda ingin dari kuda ?";
		T.yes = "Ya";
		T.no = "Tidak";
		T.choimoi = "Game Baru";
		T.choi_daco_TK = "Lanjut";
		T.daco_TK = "Masuk";
		T.doi_TK_khac = "Ganti Account";
		T.minutes = "menit";
		T.changeScrennSmall = "Resolusi rendah";
		T.normalScreen = "Resolusi tinggi";
		T.changeSizeScreen = "Game harus direstart untuk merubah resolusi, lanjutkan?";
		T.del = "Hapus";
		T.username = "Nama pengguna";
		T.password = "Kata sandi";
		T.login = "Masuk";
		T.menu = "Menu";
		T.select = "Pilih";
		T.close = "Tutup";
		T.waitLogin = "Logging, harap tunggLogging, harap tunggLogging, harap tunggLogging, harap tunggu...";
		T.nulluserpass = "Silahkan pilih karakter kamu";
		T.next = "Berikut";
		T.server = "Server";
		T.create = "Membuat";
		T.level = "Level ";
		T.Lv = "Lv";
		T.namePlayer = "Nama karakter";
		T.nameMin6char = "Nama harus setidaknya 6 karakter";
		T.back = "Kembali";
		T.remember = "Ingat";
		T.hotKey = "Hotkey";
		T.congdiem = "Tambah point";
		T.phim = "Key";
		T.giaotiep = "Berbicara";
		T.createChar = "Buat Baru";
		T.buy = "Beli";
		T.diemtiemnang = "Attribute points:";
		T.diemkynang = "Skill points:";
		T.nhanvat = "Karakter:";
		T.mainQuest = "Tugas utamTugas utama";
		T.subQuest = "Tugas sampingan";
		T.viewMap = "Peta";
		T.nhan = "Terima";
		T.tra = "Selesai";
		T.cancel = "Batal";
		T.quest = "Quest";
		T.chat = "Chat";
		T.noMessage = "Tidak ada pesan";
		T.delTabChat = "Tutup tab";
		T.read = "Baca";
		T.view = "Lihat";
		T.change = "Ganti";
		T.equip = "Equipment";
		T.setPoint = "Tambah point";
		T.cong = "Tambah";
		T.danglaydulieu = "Loading...";
		T.hoihuyQuest = "Apakah kamu mau mundur dari quest ini?";
		T.hoiBuy = "Apakah kamu mau membeli? ";
		T.pleaseWait = "Harap tunggHarap tunggHarap tunggHarap tunggu";
		T.leftRing = "Ring kiri";
		T.rightRing = "Ring kanan";
		T.hoiDelItem = "Apakah kamu mau menjatuhkan item ini?";
		T.nhapsoluongcanmua = "Masukkan jumlah yang ingin dibeli:";
		T.khongcovatphanphuhop = "Inventory tidak ada item yang cocok";
		T.cong1diem = "Apakah kamu ingin menambahkan 1 point?";
		T.nhapsodiem = "Masukkan jumlah point ke";
		T.nhohonhoacbang = "lebih kecil atau sama dengan";
		T.cong1kynang = "Apakah kamu ingin menambahkan 1 skill point";
		T.setKey = "Set Tombol";
		T.nhatdcvatpham = "ambil item";
		T.farfocus = "Target terlalu jauh";
		T.party = "Grup";
		T.noParty = "Tidak ada Grup yang dekat";
		T.invite = "Undang";
		T.mainLeave = "Dikeluarkan dari Grup";
		T.leave = "Keluar";
		T.mainCancle = "Grup dibubarkan";
		T.addFriend = "Tambah teman";
		T.nullParty = "Kamu tidak memiliki Grup";
		T.gianhap = "Gabung";
		T.lapnhom = "Buat Grup";
		T.khacclass = "Kamu tidak bisa menggunakan item ini";
		T.listParty = "Daftar Anggota Grup";
		T.buySell = "Bertukar";
		T.khoa = "Kunci";
		T.fullBuySell = "Maksimum 9 item dalam sekali pertuMaksimum 9 item dalam sekali pertuMaksimum 9 item dalam sekali pertuMaksimum 9 item dalam sekali pertukaran";
		T.kynangchuass = "Skill point belum siap";
		T.price = "Harga";
		T.deleteFriend = "Apakah kamu ingin menghapus orang ini dari Daftar TemaApakah kamu ingin menghapus orang ini dari Daftar TemaApakah kamu ingin menghapus orang ini dari Daftar TemaApakah kamu ingin menghapus orang ini dari Daftar Teman?";
		T.beginChat = "Mulai berbicara dengan";
		T.listFriend = "Daftar Teman";
		T.nullFriend = "Carilah teman yang lebih banyak !";
		T.hoivaonhom = "Apakah kamu mau bergabung dengan Grup ini?";
		T.hoilapnhom = "Apakah kamu mau membuat Grup?";
		T.item = "item";
		T.dungitem = "Apakah kamu mau menggunakan item ini?";
		T.use = "Pakai";
		T.underlevel = "Untuk menggunakan item ini, kamu harus mencapai lvl.";
		T.chuahoc = "Belum belajar skill ini.";
		T.yeucau = "Membutuhkan";
		T.nangluong = "MN:";
		T.delay = "Waktu tersisa:";
		T.timebuff = "Waktu tambahan:";
		T.hieuung = "Efek:";
		T.timehieuung = "Durasi buff:";
		T.tanghpdung = "HP bertambah:";
		T.tangmpdung = "MP bertambah:";
		T.phamvi = "Jarak:";
		T.phamvilan = "Efek ke Area:";
		T.somuctieu = "Jumlah target:";
		T.banthan = "Sendiri";
		T.moinguoi = "Semua orang";
		T.trongdoi = "Dalam grup";
		T.kethu = "Semua";
		T.buff = "Buff";
		T.active = "Serang";
		T.passive = "Pasif";
		T.kynang = "Ketrampilan";
		T.velang = "Kembali";
		T.muonvelang = "Mau revive langsung?";
		T.sell = "Jual";
		T.hoisell = "Apakah kamu mau menjual";
		T.LVyeucau = "Level yang Dibutuhkan:";
		T.yeucauketban = "ingin menjadi temanmu?";
		T.chapnhan = "Terima";
		T.tuchoi = "Tolak";
		T.myseft = "Inventaris";
		T.info = "Info";
		T.trochuyen = "Chat";
		T.moiParty = "Undang ke Grup";
		T.vucbo = "Jatuhkan Item";
		T.coin = "emas";
		T.gem = "gem";
		T.hoithoat = "Apakah kamu mau keluar?";
		T.exit = "Keluar";
		T.dangdangnhap = "Menyambung Ke Server. Harap Tunggu.";
		T.hoiFrist = "Apakah kamu pernah bermain atau memiliki account Ksatria Online sebelumnyApakah kamu pernah bermain atau memiliki account Ksatria Online sebelumnyApakah kamu pernah bermain atau memiliki account Ksatria Online sebelumnyApakah kamu pernah bermain atau memiliki account Ksatria Online sebelumnya?";
		T.oldPlayer = "Ya";
		T.newPlayer = "Tidak";
		T.register = "Registrasi";
		T.help = "Bantuan";
		T.clearData = "Hapus Data";
		T.lienhe = "Apakah kamu mau mereset kata sandi di website?";
		T.dacotaikhoan = "Telah memiliki account";
		T.dagoidangky = "Informasi dikirimkan. Harap tunggu beberapa Informasi dikirimkan. Harap tunggu beberapa Informasi dikirimkan. Harap tunggu beberapa Informasi dikirimkan. Harap tunggu beberapa menit.";
		T.quenpass = "Lupa Password";
		T.thulai = "waktu server habis. Harap coba kambali";
		T.texthelpRegister = "Masukkan account dan password untuk registrasi";
		T.lostMana = "Tidak cukup energy";
		T.capdochuadu = "Level tidak cukup";
		T.nhandc = "kamu bangkit:";
		T.diemcongvao = "Point tambahan:";
		T.hoisinh = "Revive";
		T.newParty = "Buat Grup baru";
		T.oso = "Box No. ";
		T.loimoiParty = "Apakah kamu mau mengundang temanmu ke Grup. OK?";
		T.moikhoinhom = "Kamu dikeluarkan dari Grup.";
		T.giaitannhom = "Grup kamu telah dibubarkan.";
		T.roikhoinhom = "Kamu telah meninggalkan Grup.";
		T.vuataonhom = "Grup kamu berhasil dibuat.";
		T.disconnect = "Tidak ada koneksi ke server. Harap coba kembali.";
		T.hoigiaodich = "mau bertransaksi dengan kamu. Setuju?";
		T.huygiaodich = "Transaksi dibatalkan.";
		T.khongthegiaodich = "Quest item tidak bisa ditransaksikan";
		T.chuyentien = "Transfer";
		T.nhapsotien = "Masukkan jumlah uang yang mau ditransaksikan (kurang atau sama dengan 10 juta):";
		T.xacnhan = "Konfirmasi";
		T.giaodichthanhcong = "Transaksi berhasil.";
		T.giatrinhapsai = "Tidak cukup uang untuk menyelesaikan.";
		T.banmuongiaodich = "Apakah kamu periksa dan mau bertransaksi?";
		T.xincho = "Harap tunggHarap tunggHarap tunggHarap tunggu";
		T.setPk = "Ganti Bendera";
		T.dosat = "PK";
		T.on = "Nyalakan";
		T.off = "Matikan";
		T.hut = "hindari serangan";
		T.voigia = "Harga:";
		T.la = "adalah";
		T.tinden = "Inbox";
		T.khongthecong = "Point maksimum yang bisa kamu tambahkan adalaPoint maksimum yang bisa kamu tambahkan adalaPoint maksimum yang bisa kamu tambahkan adalaPoint maksimum yang bisa kamu tambahkan adalah";
		T.changeArea = "Ganti Zona";
		T.Area = "Zona";
		T.nhapsdt = "Masukkan account kamu";
		T.trora = " Kembali ";
		T.tinnhan = "Pesan";
		T.friend = "Teman";
		T.logout = "Keluar";
		T.autoHP = "Auto Penggunaan HP/MP";
		T.auto = "Auto Fungsi";
		T.autoFire = "Auto Serangan";
		T.timduongtoilang = "Ke desa White Wolf seperti yang diminta ibu kamu";
		T.again = "Coba lagi";
		T.nhanNv = "Terima";
		T.traNv = "Lapor";
		T.tacdunglen = "Memiliki efek pada";
		T.mucdohoanthanh = "Level pencapaian";
		T.khongthetraodoi = "Tidak bisa bertransaksi dengan item ini !";
		T.xinchogiaodich = "Harap tunggu transHarap tunggu transHarap tunggu transHarap tunggu transaksi";
		T.xacnhangiaodich = "Konfirmasi transaksi";
		T.chuyensang = "Bergerak ke";
		T.keypad = "keypad";
		T.touch = "sentuh";
		T.Ring = "Ring";
		T.menuChinh = "MENU";
		T.chucnang = "Fungsi";
		T.khuvuc = "Zona";
		T.chimang = "kritikal:";
		T.tatcasatthuong = "Semua damage:";
		T.satthuongvatly = "Fisik damage:";
		T.satthuonglua = "Api damage:";
		T.satthuongdoc = "Racun damage:";
		T.satthuongdien = "Listrik damage: ";
		T.nedon = "Anti damage: ";
		T.phongthu = "Bertahan:";
		T.hoihelp = "Apakah kamu mau menjalankan Tutorial untuk Pemula? Kamu bisa mematikan tips dengan meng-klik Menu>Function>Matikan Tutorial";
		T.endHelp = "Matikan Tutorial";
		T.dangketnoilai = "Mengkoneksi, harap tunggMengkoneksi, harap tunggMengkoneksi, harap tunggMengkoneksi, harap tunggu.";
		T.vetruoc = "Kembali ke awal";
		T.toitruoc = "Halaman berikut";
		T.listnull = "Tidak ada di daftar";
		T.suckhoe = "Daya tahan: ";
		T.yeusuckhoe = "Tidak cukup StamiTidak cukup StamiTidak cukup StamiTidak cukup Stamina!";
		T.tabhanhtrang = "Inventory";
		T.tabtrangbi = "Equipment";
		T.tabthongtin = "Karakter";
		T.tabkynang = "Tabel Skill";
		T.tabnhiemvu = "Misi";
		T.tabhethong = "Setting";
		T.tabchucnang = "Fungsi";
		T.strhelp = "-Control Key\n + Gunakan Arrow Key atrau Num 2,4,6, 8 untuk bergerak.\n +Num 5 (atau Select Key) 1, 3, 7, 9 untuk menggunakan hot key seperti Skill Attack dan Potion\n +Gunakan tanda * untuk membuka tab Chat, gunakan num 0 untuk mengganti tab skill Hot key.\n-NPC\n +Kamu bisa membeli Potion (HP, MP ...) di Toko Lisa & Emma.\n  +Beli armor di Toko Doubar & Alisama.\n  +Beli senjata di Hammer & Black Eye.\n  +Teleport Stone: Bepergian antar map dalam game.\n  +Simpan item kamu di Aman & Amin.\n  +Zulu: kamu bisa mengganti gaya rambut di Toko Rambut dan menerima quest harian.\n  + Wizard: upgrade equipment kamu dan menyediakan material.\n  +Zoro & Benjamin: membuat Guild, menyediakan item Guild.\n  +Commander: menerima side quest.\n  +God of Wings: membuat dan mengupgrade wing.\n\n\n           Kasatria Online\n  Development: Silver Shield Studio (VN)\n  Sound by www.freesound.org\n  Music by audionautix.com\n  Terima kasih telah bermain!";
		T.noichuyen = "Chat";
		T.download = "Download";
		T.dcchimang = "Kritis";
		T.dcxuyengiap = "Penetrasi";
		T.mau = "HP:";
		T.khangtatcast = "Anti semua damage:";
		T.xuyengiap = "Penetrasi:";
		T.satthuongbang = "Es damage:";
		T.phansatthuong = "Melawan damage:";
		T.giet = "Bunuh";
		T.nhat = "Ambil";
		T.autoItem = "Auto Ambil";
		T.fullInven = "Inventory Penuh";
		T.helpCapchar = "Klik pada angka yang benar untuk membunuh hantu!";
		T.cauhinhthap = "Grafik Rendah";
		T.naptien = "Beli";
		T.dangdungtocnay = "Item sudah di-equip";
		T.dasohuu = "Dibeli";
		T.chapnhanketban = "telah menerima request teman";
		T.hang = "Peringkat";
		T.chuanhapsdt = "Harap masukkan alamat Harap masukkan alamat Harap masukkan alamat Harap masukkan alamat email.";
		T.chuanhapmk = "Harap masukkan passHarap masukkan passHarap masukkan passHarap masukkan password.";
		T.sdtkhople = "Nomor telepon salah. (Contoh: 0912345678 atau 84918765432)";
		T.emailkhople = "Alamat email salah. (Contoh: nickname@yahoo.com atau nickname@gmail.com)";
		T.kiemtralai = "Harap periksa informasi kamu lagi, kamu memerlukannmya untuk me-recover password.";
		T.sdt = "Nomor HP:";
		T.email = "Alamat email:";
		T.nangcapyeucau = "Upgrade dibutuhkan: Lv";
		T.thongbaotuserver = "Notifikasi dari server";
		T.khongganmauvaophimnay = "Item tidak bisa ditaruh di hotkey ini";
		T.questitem = "Item quest";
		T.layra = "Ke Inventory";
		T.catvao = "Ke Storage";
		T.nhapsoluongcanlay = "Masukkan angka:";
		T.nhapsoluongcancat = "Masukkan angka:";
		T.sellmore = "Jual item:";
		T.banhetxanh = "Jual semua item biru:";
		T.banhettrang = "Jual semua item non-magic:";
		T.khongconxanh = "Tidak ada item biru:";
		T.khongcontrang = "Tidak ada item non-magic.";
		T.dotrang = "item non-magic.";
		T.doxanh = "item biru/";
		T.chiphi = "Biaya:";
		T.nguyenlieu = "Material:";
		T.tilemayman = "Lucky chance:";
		T.hoac = "atau";
		T.dapdo = "Meningkatkan";
		T.hoidapxuluong = "Apakah kamu mau mengupgrade item dengan";
		T.hay = "atau";
		T.setting = "Setting";
		T.bovatphamvao = "Pilih item yang mau kamu upgrade, aku akan membantumu";
		T.dapbangxu = "Apakah kamu mau menguprade item ini dengan";
		T.chest = "Peti Penyimpanan";
		T.namenaptien = "Beli Gem";
		T.trochuyenvoi = "Bicara pada";
		T.noEvent = "Daftar kosong";
		T.mevent = "Notifikasi";
		T.loimoikb = "Request teman";
		T.moivaoParty = "Undang untuk bergabunt dengan Grup mereka";
		T.loimoigiaodich = "Permintaan Transaksi";
		T.thachdau = "PvP";
		T.loimoithachdau = "Menantangmu di PvP";
		T.autoBuff = "Auto Buff";
		T.thongbao = "Notifikasi";
		T.hoichoniconclan = "Terima sebagai Icon Guild?";
		T.iconclan = "Ikon Guild";
		T.contentclan = "Ikon unik untuk Guild";
		T.showAuto = "Perlihatkan Info";
		T.addmemclan = "Undang ke Guild";
		T.moivaoclan = "undang untuk bergabung dengan Guild mereka";
		T.loimoivaoclan = "Meminta Guild";
		T.clan = "Guild";
		T.bieutuong = "Ikon:";
		T.chuakhauhieu = "Tidak Memiliki Slogan.";
		T.xinvaoclan = "Minta bergabung dengan Guild";
		T.xemdanhsach = "Daftar Anggota";
		T.gop = "Kontribusi";
		T.nhapsoxumuongop = "Masukkan jumlah Gold yang mau kamu kontribusikan ke Guild:";
		T.nhapsoluongmuongop = "Masukkan jumlah Gem yang mau kamu kontribusikan ke Guild:";
		T.doiSlogan = "Ganti Slogan";
		T.doiNoiquy = "Ganti Peraturan";
		T.phonghacap = "Promosi/Downgrade";
		T.nhapthongtindoi = "Masukkan info yang ingin kamu ganti:";
		T.slogan = "Slogan";
		T.noiquy = "Peraturan";
		T.thanhvien = "Anggota";
		T.chucvu = "Peringkat:";
		T.moiroiclan = "Keluarkan dari Guild";
		T.roiclan = "Tinggalkan Guild";
		T.tabThuLinh = "Pemimpin Guild";
		T.tabBangHoi = "Guild";
		T.chattoanbang = "Chat Guild";
		T.doithongbao = "Ganti Notifikasi";
		T.bankhongconclan = "Kamu tidak berada dalam Guild";
		T.soluong = "Gem:";
		T.donggopclan = "Kontribusi ke Guild";
		T.quyxu = "Gold yang disumbangkan";
		T.quyngoc = "Gem yang disumbangkan";
		T.hoibatdosat = "Apakah kamu mau menyalakan PK mode";
		T.update = "UpdatDaftar";
		T.minimap = "Map mini";
		T.textkenhthegioi = "Chat Dunia";
		T.text2kenhthegioi = "Channel Dunia - ";
		T.kenhthegioi = "Apakah kamu mau chat di World Channel";
		T.noidungnhusau = "dengan isi berikut:";
		T.nhapnoidung = "Masukkan isi:";
		T.chatParty = "Chat Grup";
		T.phi = "Biaya";
		T.replace = "Transfer Item";
		T.hoichuyendo = "Apakah kamu mau mentransfer level upgrade dari";
		T.qua = "ke";
		T.dochuyen = "Item dipakai untuk transfer:";
		T.donhan = "Item Output:";
		T.plusnhanduoc = "Hasil Transfer:";
		T.boitemreplace = "Harap pilih 2 item yang mau ditransfer. Aku akan memberi spell pada item tersebut.";
		T.nhanban = "clone";
		T.khongconhiemvu = "Tidak ada Quest baru";
		T.timeyeucau = "Waktu Upgrade:";
		T.taoCanh = "Buat Wings";
		T.hoiTaoCanh = "Apakah kamu mau membuat";
		T.Lvsudung = "Level dibutuhkan ";
		T.nangcap = "Upgrade";
		T.sudungsau = "Bisa digunakan setelah";
		T.phandon = "Reflect";
		T.hoiroiClan = "Apakah kamu mau meninggalkan Guild?";
		T.updateData = "Harap tunggu sebenData sedang didownload.";
		T.updateok = "Download data selesai.";
		T.hoinangcapcanh = "Apakah kamu mau mengupgrade";
		T.listserver = "Pilih Server";
		T.SetMusic = "Pengaturan Suara";
		T.maychu = "Server";
		T.tuoi = "Umur:";
		T.tancong = "Serangan:";
		T.choan = "Feed";
		T.lockMap = "World Map Function sedang memblokir";
		T.delMess = "Hapus pesan";
		T.khongthedung = "Tidak bisa digunakan";
		T.about = "About";
		T.textabout1 = "Ksatria Online\nVersion:";
		T.textabout2 = "Silver Bat Studio (VN)\nSound by www.freesound.org\nMusic by audionautix.com\nFor Help: knight.online.ssvn@gmail.com";
		T.nokiaprivacy = "Privasi";
		T.thoigianaptrung = "Waktu berjalan";
		T.aptrung = "Hatch";
		T.nhaptaikhoan = "Nama pengguna (jika ada)";
		T.choi = "Main";
		T.moly = "Lotere";
		T.startdraw = "Mulai";
		T.choitiep = "Tarik ulang";
		T.chonlai = "Pilih ulang";
		T.hopNguyenLieu = "Taruh lima material yang tipenya sama, aku akan membantu kamu";
		T.hopThanh = "Kombinasi";
		T.YOUNEED = "Kamu harus memiliki";
		T.phonghacap = "Naik/Turunkan Pangkat";
		T.moiroiclan = "Pecat Dari Guild";
		T.donggopclan = "Kontribusi";
		T.info = "Informasi";
		T.trochuyen = "Chat";
		T.xemdanhsach = "Daftar Anggota";
		T.mhang = new string[4] { "I", "II", "III", "IV" };
		T.mChucVuClan = new string[7] { "Pemimpin", "Wakil Pemimpin", "Great Knight", "Noble Knight", "Knights of Honor", "Anggota Baru", "telah meninggalkan Guild" };
		T.mVolume = new string[2] { "Background Music:", "Sound:" };
		T.textCreateChar = new string[4] { "Kelas", "Rambut", "Mata", "Kepala" };
		T.mClass = new string[4] { "Ksatria", "Assassin", "Penyihir", "Penembak" };
		T.mCreateChar_HAIR = new string[2][]
		{
			new string[2] { "Straw", "Dust" },
			new string[2] { "Panjang", "Pendek" }
		};
		T.mCreateChar_EYE_FACE = new string[2][]
		{
			new string[4] { "Hitam", "Biru", "Hitam", "Biru" },
			new string[2] { "Normal", "Elf" }
		};
		T.mKyNang = new string[4] { "Strength", "Dexterity", "Vitality", "Intelligent" };
		T.story = new string[8] { "Lebih dari 500 tahun lalu", "negara besar ini menjadi area pertempuran dari 2 pasukan kerajaan kuno. + Pada saat itu", "Semua orang hidup dalam ketakutan ketika monster mengerikan muncul. + Peperangan pun akhirnya selesai", "Tapi meninggalkan kesusahan karena orang orang yang masih bertahan berusaha membangun kedamaian", "The Fellowship of Knights diciptakan untuk melindungi negara dan rakyat. + Cerita tentang keberanian dan kepahlawanan pun menyebar", "dan kemudian menjadi impian dari semua anak-anak muda untuk tumbuh besar dan menjadi ksatria yang hebat.", "Kamu menjadi dewasa", "dan sekarang waktunya kamu menerima tantangan ini dan membuktikan kamu siap bergabung dengan The Fellowship of Knights" };
		T.mColorPk = new string[10] { "Lepaskan Bendera", "Merah", "Hijau", "Biru", "Kuning", "Ungu", "Orange", "Merah", "Biru", "Hitam" };
		T.mAuto = new string[2] { "Gunakan potion HP jika HP lebih rendah dari", "Gunakan potion MP jika MP lebih rendah dari" };
		T.mUtien = new string[2] { "Prioritas: < kecil ke besar >", "Prioritas: < kecil ke besar >" };
		T.mAutoItem = new string[3] { "Item", "MP,HP", "Gold" };
		T.mValueAutoItem = new string[3][]
		{
			new string[6] { "Ambil semua", "Ambil dari item biru", "Ambil dari item kuning", "Loot dari item ungu", "Loot dari item Orange", "Tidak mau Ambil " },
			new string[4] { "Ambil all", "Hanya Ambil HP", "Hanya Ambil MP", "Tidak Ambil" },
			new string[2] { "Ambil", "Tidak mau Ambil" }
		};
		T.helpMenu = new string[1] { "Klik di sini" };
		T.mQuest = new string[2] { "Sedang diproses", "Selesai" };
		T.mHelp = new string[10][]
		{
			new string[5] { "Selamat datang di dunia Ksatria Online.", "Ini adalah instruksi untuk pemula. ", "Tekan 2 untuk ke atas, 8 untuk ke bawah, 4 ke kiri dan 6 ke kanan.", "Bisa juga menggunakan tombol panah.", "Harap bergerak ke posisi warna kuning di layar. " },
			new string[10]
			{
				" Bagus, berikutnya bisa gunakan 5 untuk memukul monster.",
				" Tanda panah di atas menunjukkan ke mana kamu meng-aim ",
				string.Empty,
				"Membunuh satu monster itu sangat gampang. Ketika kamu memukul monster kamu akan menerima experience.",
				" Kamu juga akan menerima item. Sekarang coba pukul beberapa monster.",
				string.Empty,
				"Item yang kamu ambil akan masuk ke inventory",
				"Pergi ke inventory untuk melihat apa isinya.",
				"Untuk melakukannya, klik kiri dan pilih inventory - Karakter .",
				"Klik kiri dan pilih Inventory - Character "
			},
			new string[13]
			{
				"Ini adalah inventory, kamu bisa menaruh segalanya di sini. ", "Sekarang kamu punya beberapa healing potion, mana potion dan 1 shoes. ", "Coba gunakan healing potion dengan menggerakkan kotak putih ke healing potion. ", "Klik kiri dan gunakan ", "Klik dan gunakan", "Bagus sekali, ada cara lain untuk menggunakan healing potion dan mana potion dengan membuat short cut agar lebih cepat. ", "Kamu bisa menggunakan HOT KEY untuk bertindak lebih cepat.", "Gerakkan cursor ke healing potion dan pilih kembali.", "Gunakan HOT KEY kali ini dan pilih tombol yang kamu sukai.", "Pilih dan klik HOT KEY.",
				"Klik Pilih dan pilih HOT KEY. ", "Lakukan yang serupa untuk mana potion.", "Coba gunakan HOT KEY jika diperlukan."
			},
			new string[9] { "Ada shoes baru di inventory kamu.", "Selain mempercantik dirimu, itu juga membuatmu lebih kuat.", "Mengequip shoes akan menaikkan health kamu.", "Coba equip sekarang", "Klik Pilih dan pilih Use. ", "Mudah kan? ", "Apapun yang kamu equip akan muncul di inventory. ", "Pilih inventory untuk melihat apa yang kamu miliki. ", "Gerakkan cursormu kemari." },
			new string[10] { "Informasi karakter memberitahu pakaian apa yang kamu pakai.", "Sisi kiri menunjukkan karakter dan ketahananmu terhadap efek.", "Sisi kanan menunjukkan attack power dan defense.", "Ini adalah apa yang kamu pakai.", "Kalau kamu mau mengequip item di inventory. ", "Pilih slot yang kamu inginkan dan ganti itemmu. ", "Ini juga cara yang bagus untuk membandingkan kekuatan item-item yang berbeda.", "Cobalah ini saat kamu mendapatkan loot baru.", "Ayo, kembali bertualang.", "Klik kanan untuk keluar." },
			new string[8]
			{
				string.Empty,
				"Map mini memberikan gambaran yang lebih besar tentang posisimu.",
				"Perhatikan titik kuning yang berkedip, karena itulah tempat tujuanmu.",
				"Ini adalah informasi health, mana dan level.",
				"Saat kamu memilih target, infornya akan muncul di sini.",
				"Jika kamu ingiin mengganti target, tinggal klik kiri.",
				"Kamu memiliki 2 action bar, tekan 0 untuk mengganti. ",
				"Klik * untuk chat dengan orang sekitarnya."
			},
			new string[3] { "Level Naik.Banyak hal menarik yang harus kamu tahu.", "Klik Inventory - Karakter.", " Klik kiri dan pilih Inventory - Character." },
			new string[10] { "Layar karakter akan memberitahu segala sesuatu tentang dirimu. ", "Kamu akan melihat 4 attribute: strength, dexterity, vitality & intelligence ", "Setiap kamu naik level, kamu akan mendapatkan 1 point tambahan.", "Kamu juga akan mendapat 5 point untuk ditambahkan ke karaktermu.", "Lihat ke karakter untuk melihat perbedaan.", "Coba tambah point ke health untuk melihat perubahan.", "Bergerak kemari dan klik Pilih.", "Bagus sekali. Lihat bagaimana status kamu bertambah.", "Saat kamu naik level, skill kamu juga bertambah.", "Gerakkan cursor kemari untuk melihat." },
			new string[11]
			{
				"Skill menunjukkan semua kekuatan baru yang bisa kamu pelajari.",
				"Skill aktif ada di kiri. ",
				"Kolom pertama menunjukkan physical skill dan kolomn kedua menunjukkan magic. ",
				"Passive dan Buff skill ada di kanan. ",
				"Setiap naik level akan memberimu 1 skill point.",
				"Kamu bisa mengalokasi di skill mana yang cocok untukmu.",
				"Kamu bisa reset semua skill dengan Special Potion dari Toko.",
				"Pilih skill dan klik Tambah Point.",
				"Sama dengan sebelumnya, kamu juga bisa menggunakan HOT KEY untuk bertindak lebih cepat.",
				"Gunakan HOT KEY untuk tiap tombol dan kembali untuk melihat strength.",
				string.Empty
			},
			new string[8]
			{
				"Kamu telah menerima quest baru. pergi ke Inventory - Karakter untuk melihat rincian quest.",
				"Gerakkan cursor ke sini. ",
				"Menu ini adalah catatan quest kamu. ",
				"Tab kiri menunjukkan quest yang sedang kamu lakukan.",
				"Tab kanan menunjukkan quest yang sudah selesai dan menunggu kamu kembali ke orang yang meminta tolong. ",
				"Klik ke quest apa saja kemudian LIHAT untuk detil lebih lanjut.",
				"Ingat untuk menggunakan peta untuk menunjukkan ke mana kamu harus pergi.",
				string.Empty
			}
		};
		T.mHelpPoint = new string[10][]
		{
			new string[5]
			{
				string.Empty,
				string.Empty,
				"Gunakan panah di layar untuk bergerak. ",
				"Klik suatu tempat di layar untuk bergerak ke sana. ",
				string.Empty
			},
			new string[10]
			{
				"Bagus, sekarang klik ke monster untuk membunuhnya.",
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				"Pilih Menu - Inventory - Karakter.",
				"Klik di sini dan pilih Inventory - Karakter. "
			},
			new string[13]
			{
				string.Empty,
				string.Empty,
				"Klik healing potion. ",
				"Klik lagi untuk menggunakan. ",
				"Klik di sini dan gunakan. ",
				string.Empty,
				string.Empty,
				"Pilih healing potion lagi. ",
				string.Empty,
				"Klik di sini dan pilih HOT KEY. ",
				"Klik di sini dan pilih HOT KEY. ",
				string.Empty,
				string.Empty
			},
			new string[9]
			{
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				"Klik di sini dan gunakan. ",
				string.Empty,
				string.Empty,
				string.Empty,
				"Klik di sini untuk membuka inventory. "
			},
			new string[10]
			{
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				"Klik di sini untuk kembali. "
			},
			new string[9]
			{
				string.Empty,
				" Map mini memberikan gambaran yang lebih besar tentang posisimu. ",
				" Perhatikan titik kuning yang berkedip, karena itulah tempat tujuanmu.",
				string.Empty,
				string.Empty,
				" Saat kamu memilih target, infornya akan muncul di sini.",
				" Untuk mengganti target, sentuh di sini.",
				" Kamu punya 2 action bar, sentuh di sini untuk merubahnya.",
				" Klik di sini untuk chat dengan pemain di sekitar."
			},
			new string[3]
			{
				string.Empty,
				string.Empty,
				" Klik di sini untuk memilih Inventory - Character."
			},
			new string[10]
			{
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				"Klik di sini untuk menambah point.",
				string.Empty,
				string.Empty,
				" Klik di sini untuk menambah skill points "
			},
			new string[11]
			{
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				"Pilih satu skill dan tambahkan point.",
				string.Empty,
				string.Empty,
				string.Empty
			},
			new string[8]
			{
				string.Empty,
				"Klik di sini untuk membuka Quest.",
				string.Empty,
				string.Empty,
				string.Empty,
				"Jika kamu mau tahu lebih banyak tentang quest, klik saja di sini.",
				string.Empty,
				string.Empty
			}
		};
	}
}
