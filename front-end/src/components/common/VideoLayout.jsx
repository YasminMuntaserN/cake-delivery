function videoLayout() {
  return (
<div className="relative video-container mt-[-130px]">
      {/* Video Overlay */}
<div className="absolute inset-0 bg-black/60" aria-hidden="true"></div>
      <video className=" h-80  w-full object-cover" autoPlay>
    <source src="./layout.mp4" type="video/mp4" />
    Your browser does not support the video tag.
  </video>
</div>
  )
}

export default videoLayout
