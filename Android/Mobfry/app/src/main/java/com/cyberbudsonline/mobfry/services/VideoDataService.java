package com.cyberbudsonline.mobfry.services;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Iterator;
import java.util.List;
import java.util.ListIterator;

/**
 * Created by ishan on 8/27/2014.
 */
public class VideoDataService {
    public VideoDataService(){

    }


    public List<VideoItemCategory> GetCategories(){
        List<VideoItemCategory> categories=new ArrayList<VideoItemCategory>() ;
        VideoItemCategory cat=new VideoItemCategory();
        cat.setId("1");cat.setTitle("Bollywood Promos And Trailers");cat.description="All bollywood promotions and trailer videos";
        categories.add(cat);

        cat=new VideoItemCategory();
        cat.setId("2");cat.setTitle("Bollywood HD Videos Songs");cat.description="All bollywood high definition video songs";
        categories.add(cat);

        cat=new VideoItemCategory();
        cat.setId("3");cat.setTitle("Honey Singh HD Video Songs");cat.description="All bollywood songs by Honey Singh in high definition quality";
        categories.add(cat);

        cat=new VideoItemCategory();
        cat.setId("4");cat.setTitle("Bollywood Hot Videos");cat.description="All bollywood hot vidoes from hot movies";
        categories.add(cat);

        cat=new VideoItemCategory();
        cat.setId("5");cat.setTitle("English HD Video Songs");cat.description="All english high definition video songs";
        categories.add(cat);

        return categories;

    }

}
