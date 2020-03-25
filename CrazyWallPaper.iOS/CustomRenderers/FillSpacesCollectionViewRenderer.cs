using System;
using CrazyWallPaper.iOS.CustomRenderers;
using CrazyWallPaper.Views.CustomRenderers;
using UIKit;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(FillSpacesCollectionView), typeof(FillSpacesCollectionViewRenderer))]
namespace CrazyWallPaper.iOS.CustomRenderers
{
    public class FillSpacesCollectionViewRenderer : UICollectionViewFlowLayout
    {
        public FillSpacesCollectionViewRenderer()
        {

        }

        override public void PrepareLayout()
        {


        }




    }
}
