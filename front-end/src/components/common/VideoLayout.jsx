function VideoLayout({ children }) {
  return (
    <div className="relative video-container mt-[-130px]">
      <div className="absolute top-[200px] left-[200px] text-4xl text-peach z-1000">
        {children}
      </div>
      {/* Video Overlay */}
      <div className="absolute inset-0 bg-black/60 z-0" aria-hidden="true"></div>
      <video className="sm:h-80 w-full object-fill" autoPlay muted preload="auto" loop>
        <source src="/VideoLayout.mp4" type="video/mp4" />
        Your browser does not support the video tag.
      </video>
    </div>
  );
}

export default VideoLayout;
