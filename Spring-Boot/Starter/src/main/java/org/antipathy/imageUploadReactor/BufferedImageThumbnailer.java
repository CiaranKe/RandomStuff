package org.antipathy.imageUploadReactor;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import reactor.event.Event;
import reactor.function.Function;

import javax.imageio.ImageIO;
import java.awt.*;
import java.awt.geom.AffineTransform;
import java.awt.image.BufferedImage;
import java.awt.image.ImageObserver;
import java.nio.file.Files;
import java.nio.file.Path;

public class BufferedImageThumbnailer implements Function<Event<Path>, Path>
{
    private static final ImageObserver DUMMY_OBSERVER = (img, infoflags, x,y, width, height) -> true;
    private final Logger log = LoggerFactory.getLogger(getClass());
    private final int maxLongSide;

    public BufferedImageThumbnailer(int _maxLongSide)
    {
        this.maxLongSide = _maxLongSide;
    }

    /* The thumbnailer implements Reactor’s Function interface by implementing the apply(Event<Path>) method. It
       accepts an Event whose payload is the Path to the uploaded, full-size image. It then reads in the image using
       ImageIO and determines its current dimensions. It has to calculate the scale it needs to use to shrink the image
       from its present dimensions to 250px on the longest side. If the image is square or horizontal, it uses the
       image’s width to determine that scale factor, otherwise it uses the image’s height.*/
    @Override
    public Path apply(Event<Path> ev)
    {
        try
        {
            Path srcPath = ev.getData();
            Path thumbnailPath = Files.createTempFile("thumbnail", ".jpg").toAbsolutePath();
            BufferedImage imgIn= ImageIO.read(srcPath.toFile());

            double scale;
            if (imgIn.getWidth() >= imgIn.getHeight())
            {
                //horisontal of square iamge
                scale = Math.min(maxLongSide, imgIn.getWidth()) / (double) imgIn.getWidth();
            }
            else
            {
                // vertical image
                scale = Math.min(maxLongSide, imgIn.getHeight()) / (double) imgIn.getHeight();
            }

            BufferedImage thumbnailOut = new BufferedImage((int) (scale * imgIn.getWidth()),
                                                           (int) (scale * imgIn.getHeight()),
                                                            imgIn.getType());
            Graphics2D g = thumbnailOut.createGraphics();

            AffineTransform transform = AffineTransform.getScaleInstance(scale,scale);
            g.drawImage(imgIn,transform,DUMMY_OBSERVER);
            ImageIO.write(thumbnailOut,"jpeg", thumbnailPath.toFile());
            log.info("Image thumbnail at: {}", thumbnailPath);

            return thumbnailPath;
        }
        catch (Exception e)
        {
            throw new IllegalStateException(e.getMessage(), e);
        }
    }
}
