import Flag from "../../ui/Flag";

function CustomerRow({customer }) {
  return (
    <div className={styledRow }>
          <p>{customer.firstName}  {customer.lastName}</p>
          <p>{customer.email}</p>
          <p> {customer.phoneNumber}</p>
          <Flag countryName={customer.country} />
          <p>{customer.city}</p>
          <p>{customer.postalCode}</p>

    </div>
);
}
const styledRow = `grid  grid-cols-[2fr_2fr_2fr_1fr_1fr_1fr]  gap-[2.4rem] items-center border-b border-gray-100 px-5 py-5 text-xs`;
export default CustomerRow