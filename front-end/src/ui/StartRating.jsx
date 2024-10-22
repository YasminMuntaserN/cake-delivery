import { useState } from "react";

function StartRating({maxRating =5 , onRating}) {
  const [rating ,setRating] =useState(0);
  const [tempRating ,setTempRating]=useState(rating);
  const handleRating =(i)=>{
    setRating(i+1)
    onRating(i+1)
  }
  return ( 
    <div className={StyledStarsContainer}>
      {
        Array.from({length:maxRating } ,(_, i) =>
          ( <Star 
            key={i+1}
            full={tempRating ? tempRating >= i+1 : rating >= i+1}
            onRate={()=>handleRating(i)}
            onHoverIn={()=>setTempRating(i+1)}
            onHoverOut={()=>setTempRating(0)}/>)
        )
      }
      <p className={StyledRatingNum}>{rating} / 5</p>
    </div>
  )
}

  function Star({full ,onRate ,onHoverIn ,onHoverOut}) {
  return (
    <span
      role="button"
      className={StayedStar}
      onClick={onRate}
      onMouseEnter={()=>onHoverIn}
      onMouseLeave={()=>onHoverOut}

    >
      {full ? (
        <svg
          xmlns="http://www.w3.org/2000/svg"
          viewBox="0 0 20 20"
          fill="#fcc419"
          stroke="#fcc419"
        >
          <path d="M9.049 2.927c.3-.921 1.603-.921 1.902 0l1.07 3.292a1 1 0 00.95.69h3.462c.969 0 1.371 1.24.588 1.81l-2.8 2.034a1 1 0 00-.364 1.118l1.07 3.292c.3.921-.755 1.688-1.54 1.118l-2.8-2.034a1 1 0 00-1.175 0l-2.8 2.034c-.784.57-1.838-.197-1.539-1.118l1.07-3.292a1 1 0 00-.364-1.118L2.98 8.72c-.783-.57-.38-1.81.588-1.81h3.461a1 1 0 00.951-.69l1.07-3.292z" />
        </svg>
      ) : (
        <svg
          xmlns="http://www.w3.org/2000/svg"
          fill="none"
          viewBox="0 0 24 24"
          stroke="#fcc419"
        >
          <path
            strokeLinecap="round"
            strokeLinejoin="round"
            strokeWidth="{2}"
            d="M11.049 2.927c.3-.921 1.603-.921 1.902 0l1.519 4.674a1 1 0 00.95.69h4.915c.969 0 1.371 1.24.588 1.81l-3.976 2.888a1 1 0 00-.363 1.118l1.518 4.674c.3.922-.755 1.688-1.538 1.118l-3.976-2.888a1 1 0 00-1.176 0l-3.976 2.888c-.783.57-1.838-.197-1.538-1.118l1.518-4.674a1 1 0 00-.363-1.118l-3.976-2.888c-.784-.57-.38-1.81.588-1.81h4.914a1 1 0 00.951-.69l1.519-4.674z"
          />
        </svg>
      )}
    </span>
  );
}
const StayedStar="block w-[48px] h-[48px] pointer";
const StyledStarsContainer="flex my-5 ml-5";
const StyledRatingNum="text-3xl text-basic ml-5 mt-2";

export default StartRating
