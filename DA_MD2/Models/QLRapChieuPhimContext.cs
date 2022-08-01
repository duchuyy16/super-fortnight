using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DA_MD2.Models
{
    public partial class QLRapChieuPhimContext : DbContext
    {
        public QLRapChieuPhimContext()
        {
        }

        public QLRapChieuPhimContext(DbContextOptions<QLRapChieuPhimContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ghe> Ghes { get; set; }
        public virtual DbSet<LichChieu> LichChieus { get; set; }
        public virtual DbSet<LoaiGhe> LoaiGhes { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<Phim> Phims { get; set; }
        public virtual DbSet<Phong> Phongs { get; set; }
        public virtual DbSet<Rap> Raps { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<SuatChieu> SuatChieus { get; set; }
        public virtual DbSet<TheLoaiPhim> TheLoaiPhims { get; set; }
        public virtual DbSet<Ve> Ves { get; set; }
        public virtual DbSet<XepHangPhim> XepHangPhims { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=MSI\\HUYSQLSERVER;Database=QLRapChieuPhim;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Ghe>(entity =>
            {
                entity.ToTable("Ghe");

                entity.Property(e => e.Day)
                    .HasMaxLength(1)
                    .IsFixedLength(true);

                entity.Property(e => e.SoGhe)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdLoaiGheNavigation)
                    .WithMany(p => p.Ghes)
                    .HasForeignKey(d => d.IdLoaiGhe)
                    .HasConstraintName("FK_Ghe_LoaiGhe");

                entity.HasOne(d => d.IdPhongNavigation)
                    .WithMany(p => p.Ghes)
                    .HasForeignKey(d => d.IdPhong)
                    .HasConstraintName("FK_Ghe_Phong");
            });

            modelBuilder.Entity<LichChieu>(entity =>
            {
                entity.ToTable("LichChieu");

                entity.Property(e => e.NgayChieu).HasColumnType("date");

                entity.HasOne(d => d.IdPhimNavigation)
                    .WithMany(p => p.LichChieus)
                    .HasForeignKey(d => d.IdPhim)
                    .HasConstraintName("FK_LichChieu_Phim");

                entity.HasOne(d => d.IdPhongNavigation)
                    .WithMany(p => p.LichChieus)
                    .HasForeignKey(d => d.IdPhong)
                    .HasConstraintName("FK_LichChieu_Phong");

                entity.HasOne(d => d.IdSuatChieuNavigation)
                    .WithMany(p => p.LichChieus)
                    .HasForeignKey(d => d.IdSuatChieu)
                    .HasConstraintName("FK_LichChieu_SuatChieu");
            });

            modelBuilder.Entity<LoaiGhe>(entity =>
            {
                entity.ToTable("LoaiGhe");

                entity.Property(e => e.TenLoaiGhe).HasMaxLength(100);
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.ToTable("NhanVien");

                entity.Property(e => e.Cmnd)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.DiaChi).HasMaxLength(200);

                entity.Property(e => e.HoTen)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.MatKhau)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NgaySinh).HasColumnType("date");

                entity.HasOne(d => d.IdRapNavigation)
                    .WithMany(p => p.NhanViens)
                    .HasForeignKey(d => d.IdRap)
                    .HasConstraintName("FK_NhanVien_Rap");
            });

            modelBuilder.Entity<Phim>(entity =>
            {
                entity.ToTable("Phim");

                entity.Property(e => e.DanhSachIdTheLoai)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DaoDien).HasMaxLength(100);

                entity.Property(e => e.DienVien).HasMaxLength(200);

                entity.Property(e => e.NgayKhoiChieu).HasColumnType("date");

                entity.Property(e => e.NgonNgu).HasMaxLength(100);

                entity.Property(e => e.NhaSanXuat).HasMaxLength(200);

                entity.Property(e => e.NuocSanXuat).HasMaxLength(200);

                entity.Property(e => e.Poster).IsUnicode(false);

                entity.Property(e => e.TenGoc).HasMaxLength(200);

                entity.Property(e => e.TenPhim)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Trailer)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdXepHangPhimNavigation)
                    .WithMany(p => p.Phims)
                    .HasForeignKey(d => d.IdXepHangPhim)
                    .HasConstraintName("FK_Phim_XepHangPhim");
            });

            modelBuilder.Entity<Phong>(entity =>
            {
                entity.ToTable("Phong");

                entity.Property(e => e.GhiChu).HasMaxLength(200);

                entity.Property(e => e.TenPhong).HasMaxLength(100);

                entity.HasOne(d => d.IdRapNavigation)
                    .WithMany(p => p.Phongs)
                    .HasForeignKey(d => d.IdRap)
                    .HasConstraintName("FK_Phong_Rap");
            });

            modelBuilder.Entity<Rap>(entity =>
            {
                entity.ToTable("Rap");

                entity.Property(e => e.DiaChi).HasMaxLength(200);

                entity.Property(e => e.DienThoai).HasMaxLength(100);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.TenRap).HasMaxLength(200);
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Rating");

                entity.Property(e => e.Ip)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ngay).HasColumnType("datetime");
            });

            modelBuilder.Entity<SuatChieu>(entity =>
            {
                entity.ToTable("SuatChieu");

                entity.Property(e => e.GioBatDau)
                    .HasMaxLength(5)
                    .IsFixedLength(true);

                entity.Property(e => e.GioKetThuc)
                    .HasMaxLength(5)
                    .IsFixedLength(true);

                entity.Property(e => e.TenSuatChieu).HasMaxLength(100);
            });

            modelBuilder.Entity<TheLoaiPhim>(entity =>
            {
                entity.ToTable("TheLoaiPhim");

                entity.Property(e => e.Ten)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Ve>(entity =>
            {
                entity.ToTable("Ve");

                entity.Property(e => e.NgayBanVe).HasColumnType("datetime");

                entity.Property(e => e.SoGhe)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TinhTrang).HasComment("0: Còn trống; 1: Đã bán; 2: Đặt chổ");

                entity.HasOne(d => d.IdLichChieuNavigation)
                    .WithMany(p => p.Ves)
                    .HasForeignKey(d => d.IdLichChieu)
                    .HasConstraintName("FK_Ve_LichChieu");

                entity.HasOne(d => d.IdNhanVienNavigation)
                    .WithMany(p => p.Ves)
                    .HasForeignKey(d => d.IdNhanVien)
                    .HasConstraintName("FK_Ve_NhanVien");
            });

            modelBuilder.Entity<XepHangPhim>(entity =>
            {
                entity.ToTable("XepHangPhim");

                entity.Property(e => e.KyHieu)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Ten).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
