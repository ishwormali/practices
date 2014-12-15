package com.cyberbudsonline.mobfry.services;

/**
 * Created by ishan on 8/27/2014.
 */
public class VideoItemBase {

    private String videoId;

    public void setVideoId(String videoId) {
        this.videoId = videoId;
    }

    public String getVideoId() {
        return videoId;
    }

    private String videoName;

    public void setVideoName(String videoName) {
        this.videoName = videoName;
    }

    public String getVideoName() {
        return videoName;
    }

    private String category;

    public void setCategory(String category) {
        this.category = category;
    }

    public String getCategory() {
        return category;
    }
}
