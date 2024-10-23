import { FaLinkedin, FaGithub, FaTelegram } from 'react-icons/fa';

function ContactLinks() {
  return (
      <div className="lg:w-1/3 md:w-full mt-10">
      <p className={StyledCopyRight}>© Cakes By Yasmina 2024. All rights reserved. Website created by <span className="text-white">Yasmin Muntaser</span></p>
      <div className="flex mt-4">
          <a className={StyledText} href="https://t.me/yasmin_MunN">
          <FaTelegram className={StyledIcon} />
          </a>
          <a className={StyledText} href="https://github.com/YasminMuntaserN">
          <FaGithub className={StyledIcon} />
          </a>
          <a className={StyledText} href="https://www.linkedin.com/in/yasmin-muntaser-908411294/">
              <FaLinkedin className={StyledIcon} />
          </a>
      </div>
  </div>
  )
}
const StyledCopyRight ="text-lg text-gray-600";
const StyledText ="btn btn-lg border border-peach rounded-lg mr-2 bg-pink text-white p-2";
const StyledIcon ="h-6 w-6";


export default ContactLinks
