import { HiMiniGlobeAsiaAustralia ,HiEnvelopeOpen, HiMiniPhone} from "react-icons/hi2";

function GetInTouch() {
return (
<div className="lg:w-1/3 md:w-full pt-5 mb-5">
    <h4 className={StyledHeader}>Get In Touch</h4>
    <div className={StyledContainer}>
    <HiMiniGlobeAsiaAustralia className={StyledIcon} />
        <p className={StyledText}>123 Street, Gaza, Palestine</p>
    </div>
    <div className={StyledContainer}>
    <a href="yasminmun13@gmail.com"><HiEnvelopeOpen className={StyledIcon}/></a>
        <p className={StyledText}>Yasminmun13@gamil.com</p>
    </div>
    <div className={StyledContainer}>
    <HiMiniPhone className={StyledIcon}/>
        <p className={StyledText}>+012 345 67890</p>
    </div>
</div>

)
}

const StyledHeader="text-lg md:text-xl text-pink font-semibold uppercase mb-6";
const StyledIcon ="w-5 h-5 text-gray-600 ml-3";
const StyledText ="flex gap-3  mb-0 ";
const StyledContainer="flex mb-2 gap-3";
export default GetInTouch
