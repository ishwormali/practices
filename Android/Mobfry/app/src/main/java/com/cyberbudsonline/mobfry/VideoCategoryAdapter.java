package com.cyberbudsonline.mobfry;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import com.cyberbudsonline.mobfry.services.VideoItemCategory;

import java.util.List;

/**
 * Created by ishan on 8/28/2014.
 */
public class VideoCategoryAdapter extends ArrayAdapter<VideoItemCategory> {


    private Context context;
    private List<VideoItemCategory> categoryList;
    public VideoCategoryAdapter(Context context, List<VideoItemCategory> categoryList ) {
        super(context,R.layout.category_item_layout,categoryList);
        this.context=context;
        this.categoryList=categoryList;
    }

    public View getView(int position, View convertView, ViewGroup parent){
        LayoutInflater inflater=(LayoutInflater)context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        View itemView=inflater.inflate(R.layout.category_item_layout,parent,false);
        TextView titleView=(TextView)itemView.findViewById(R.id.category_title);
        TextView descriptionView=(TextView)itemView.findViewById(R.id.category_description);
        VideoItemCategory category=categoryList.get(position);
        titleView.setText(category.getTitle());
        descriptionView.setText(category.description);
        return itemView;
    }

}
