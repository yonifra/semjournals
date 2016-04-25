using System.IO;
using System.Windows;
using SEMJournals.Win.ViewModels;
using TallComponents.PDF.Rasterizer;
using TallComponents.PDF.Rasterizer.Configuration;
using TallComponents.PDF.Rasterizer.Diagnostics;

namespace SEMJournals.Win.Views
{
    /// <summary>
    /// Interaction logic for SemViewerControl.xaml
    /// </summary>
    public partial class SemViewerControl
    {
        public static readonly DependencyProperty JournalProperty = DependencyProperty.Register("Journal", typeof(JournalViewModel), typeof(SemViewerControl), new FrameworkPropertyMetadata(null, OnJournalPropertyChanged));

        private static void OnJournalPropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            var control = source as SemViewerControl;
            var journal = (JournalViewModel)e.NewValue;

            if (journal != null && control != null)
            {
                LoadDocument(control, journal.DocumentPath);
            }
        }

        public SemViewerControl()
        {
            InitializeComponent();
        }

        public JournalViewModel Journal
        {
            get { return (JournalViewModel)GetValue(JournalProperty); }
            set { SetValue(JournalProperty, value); }
        }

        /// <summary>
        /// Creates an DocumentSource from the PDF and sets the document source of the document viewer accordingly
        /// </summary>
        /// <param name="ctrl">The control</param>
        /// <param name="path">Path to the PDF file</param>
        private static void LoadDocument(SemViewerControl ctrl, string path)
        {
            using (var file = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                var pdfDoc = new Document(file);

                var convertOptions = new ConvertToWpfOptions();
                var renderSettings = new RenderSettings();

                var wpfDoc = pdfDoc.ConvertToWpf(renderSettings, convertOptions, 0, 9, new Summary());
                ctrl.DocumentViewer.Document = wpfDoc;
            }
        }
    }
}
