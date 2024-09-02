using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace PhotoEditor
{
    public partial class Form1 : Form
    {
        private string filePath = string.Empty;

        public Form1()
        {
            InitializeComponent();
            ApplySystemTheme();
        }

        private void ApplySystemTheme()
        {
            bool isDarkTheme = IsDarkMode();

            // Цвета фона и текста
            this.BackColor = isDarkTheme ? Color.FromArgb(30, 30, 30) : Color.White;
            this.ForeColor = isDarkTheme ? Color.LightGray : Color.Black;

            // Цвета кнопок
            btnSelectImage.BackColor = isDarkTheme ? Color.FromArgb(50, 50, 50) : Color.LightGray;
            btnSelectImage.ForeColor = isDarkTheme ? Color.LightGray : Color.Black;
            btnCompress.BackColor = isDarkTheme ? Color.FromArgb(50, 50, 50) : Color.LightGray;
            btnCompress.ForeColor = isDarkTheme ? Color.LightGray : Color.Black;
            btnConvert.BackColor = isDarkTheme ? Color.FromArgb(50, 50, 50) : Color.LightGray;
            btnConvert.ForeColor = isDarkTheme ? Color.LightGray : Color.Black;

            // Цвета комбобоксов
            cmbOutputFormat.BackColor = isDarkTheme ? Color.FromArgb(50, 50, 50) : Color.White;
            cmbOutputFormat.ForeColor = isDarkTheme ? Color.LightGray : Color.Black;

            // Цвета текстовых полей
            txtFilePath.BackColor = isDarkTheme ? Color.FromArgb(40, 40, 40) : Color.White;
            txtFilePath.ForeColor = isDarkTheme ? Color.LightGray : Color.Black;

            // Цвет фона для PictureBox
            pictureBox.BackColor = isDarkTheme ? Color.FromArgb(20, 20, 20) : Color.White;

            // Границы PictureBox (можно использовать тёмно-серый цвет для выделения)
            pictureBox.BorderStyle = isDarkTheme ? BorderStyle.FixedSingle : BorderStyle.None;
        }

        private bool IsDarkMode()
        {
            try
            {
                using (var key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize"))
                {
                    if (key != null)
                    {
                        var value = key.GetValue("SystemUsesLightTheme");
                        if (value != null && (int)value == 0)
                        {
                            return true;
                        }
                    }
                }
            }
            catch
            {
                // Если произошла ошибка при чтении реестра, предполагаем светлую тему.
            }
            return false;
        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.png;*.jpg;*.jpeg;*.bmp;*.gif;*.tiff;*.webp;*.dds";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    txtFilePath.Text = filePath;
                    LoadImage(filePath);
                }
            }
        }

        private void LoadImage(string path)
        {
            try
            {
                pictureBox.Image?.Dispose();
                pictureBox.Image = Image.FromFile(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}");
            }
        }

        private void btnCompress_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                MessageBox.Show("Please select an image first.");
                return;
            }

            try
            {
                string extension = Path.GetExtension(filePath).ToLower();

                switch (extension)
                {
                    case ".jpg":
                    case ".jpeg":
                        CompressJpeg();
                        break;
                    case ".png":
                        CompressPng();
                        break;
                    case ".gif":
                        CompressGif();
                        break;
                    case ".bmp":
                        CompressBmp();
                        break;
                    case ".tiff":
                        CompressTiff();
                        break;
                    case ".webp":
                        CompressWebP();
                        break;
                    case ".dds":
                        CompressDDS();
                        break;
                    default:
                        MessageBox.Show("Unsupported image format for compression.");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error compressing image: {ex.Message}");
            }
        }

        private void CompressJpeg()
        {
            using (var image = Image.FromFile(filePath))
            {
                var resizedImage = ResizeImage(image, 0.5);
                var encoder = GetEncoder(ImageFormat.Jpeg);
                var encoderParameters = new EncoderParameters(1);
                encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, 75L);

                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "JPEG Image|*.jpg;*.jpeg",
                    DefaultExt = "jpg",
                    FileName = Path.GetFileNameWithoutExtension(filePath) + "_compressed.jpg"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    resizedImage.Save(saveFileDialog.FileName, encoder, encoderParameters);
                    MessageBox.Show("Image compressed and saved.");
                }
            }
        }

        private void CompressPng()
        {
            using (var image = Image.FromFile(filePath))
            {
                var resizedImage = ResizeImage(image, 0.5);
                SaveCompressedImage(resizedImage, ImageFormat.Png, "PNG Image|*.png");
            }
        }

        private void CompressGif()
        {
            using (var image = Image.FromFile(filePath))
            {
                var resizedImage = ResizeImage(image, 0.5);
                SaveCompressedImage(resizedImage, ImageFormat.Gif, "GIF Image|*.gif");
            }
        }

        private void CompressBmp()
        {
            using (var image = Image.FromFile(filePath))
            {
                var resizedImage = ResizeImage(image, 0.5);
                SaveCompressedImage(resizedImage, ImageFormat.Bmp, "BMP Image|*.bmp");
            }
        }

        private void CompressTiff()
        {
            using (var image = Image.FromFile(filePath))
            {
                var resizedImage = ResizeImage(image, 0.5);
                var encoder = GetEncoder(ImageFormat.Tiff);
                var encoderParameters = new EncoderParameters(1);
                encoderParameters.Param[0] = new EncoderParameter(Encoder.Compression, (long)EncoderValue.CompressionLZW);

                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "TIFF Image|*.tiff;*.tif",
                    DefaultExt = "tiff",
                    FileName = Path.GetFileNameWithoutExtension(filePath) + "_compressed.tiff"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    resizedImage.Save(saveFileDialog.FileName, encoder, encoderParameters);
                    MessageBox.Show("Image compressed and saved.");
                }
            }
        }

        private void CompressWebP()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "WebP Image|*.webp",
                DefaultExt = "webp",
                FileName = Path.GetFileNameWithoutExtension(filePath) + "_compressed.webp"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string outputFile = Path.GetFullPath(saveFileDialog.FileName);
                var process = new System.Diagnostics.Process();
                process.StartInfo.FileName = "cwebp.exe";
                process.StartInfo.Arguments = $"-resize 50% 50% -q 75 \"{filePath}\" -o \"{outputFile}\"";
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.Start();
                process.WaitForExit();

                if (process.ExitCode == 0)
                {
                    MessageBox.Show("WebP image compressed and saved.");
                }
                else
                {
                    MessageBox.Show("Error compressing WebP image.");
                }
            }
        }

        private void CompressDDS()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "DDS Image|*.dds",
                DefaultExt = "dds",
                FileName = Path.GetFileNameWithoutExtension(filePath) + "_compressed.dds"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string outputFile = Path.GetFullPath(saveFileDialog.FileName);
                var tempFile = Path.Combine(Path.GetTempPath(), Path.GetFileName(filePath));

                // Resize the image and save as a temporary PNG
                using (var image = Image.FromFile(filePath))
                {
                    var resizedImage = ResizeImage(image, 0.5);
                    resizedImage.Save(tempFile, ImageFormat.Png);
                }

                var process = new System.Diagnostics.Process();
                process.StartInfo.FileName = "texconv.exe";
                process.StartInfo.Arguments = $"-f DXT1 \"{tempFile}\" -o \"{Path.GetDirectoryName(outputFile)}\" -nologo";
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.Start();
                process.WaitForExit();

                File.Delete(tempFile); // Delete temporary file

                if (process.ExitCode == 0)
                {
                    MessageBox.Show("DDS image compressed and saved.");
                }
                else
                {
                    MessageBox.Show("Error compressing DDS image.");
                }
            }
        }

        private void SaveCompressedImage(Image image, ImageFormat format, string filter)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = filter,
                DefaultExt = format.ToString().ToLower(),
                FileName = Path.GetFileNameWithoutExtension(filePath) + "_compressed." + format.ToString().ToLower()
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                image.Save(saveFileDialog.FileName, format);
                MessageBox.Show("Image saved.");
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                MessageBox.Show("Please select an image first.");
                return;
            }

            if (cmbOutputFormat.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an output format.");
                return;
            }

            try
            {
                string format = cmbOutputFormat.SelectedItem.ToString().ToLower();
                string extension = format == "jpeg" ? "jpg" : format;

                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = $"{format.ToUpper()} Image|*.{extension}",
                    DefaultExt = extension,
                    FileName = Path.GetFileNameWithoutExtension(filePath) + $".{extension}"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string outputFile = saveFileDialog.FileName;

                    switch (format)
                    {
                        case "jpeg":
                        case "jpg":
                            ConvertImage(ImageFormat.Jpeg, outputFile);
                            break;
                        case "png":
                            ConvertImage(ImageFormat.Png, outputFile);
                            break;
                        case "gif":
                            ConvertImage(ImageFormat.Gif, outputFile);
                            break;
                        case "bmp":
                            ConvertImage(ImageFormat.Bmp, outputFile);
                            break;
                        case "tiff":
                            ConvertImage(ImageFormat.Tiff, outputFile);
                            break;
                        case "webp":
                            ConvertToWebP(outputFile);
                            break;
                        default:
                            MessageBox.Show("Unsupported image format for conversion.");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error converting image: {ex.Message}");
            }
        }

        private void ConvertImage(ImageFormat format, string outputFile)
        {
            using (var image = Image.FromFile(filePath))
            {
                image.Save(outputFile, format);
                MessageBox.Show($"Image converted and saved as {outputFile}");
            }
        }

        private void ConvertToWebP(string outputFile)
        {
            var process = new System.Diagnostics.Process();
            process.StartInfo.FileName = "cwebp.exe";
            process.StartInfo.Arguments = $"-q 75 \"{filePath}\" -o \"{outputFile}\"";
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();
            process.WaitForExit();

            if (process.ExitCode == 0)
            {
                MessageBox.Show("Image converted to WebP and saved.");
            }
            else
            {
                MessageBox.Show("Error converting image to WebP.");
            }
        }

        private Image ResizeImage(Image image, double scale)
        {
            int newWidth = (int)(image.Width * scale);
            int newHeight = (int)(image.Height * scale);
            var resizedImage = new Bitmap(newWidth, newHeight);

            using (var graphics = Graphics.FromImage(resizedImage))
            {
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);
            }

            return resizedImage;
        }

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            var codecs = ImageCodecInfo.GetImageDecoders();
            foreach (var codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }
    }
}
