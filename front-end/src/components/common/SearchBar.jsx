import React from 'react';
import { useForm } from 'react-hook-form';

function SearchBar() {
      const { register, handleSubmit } = useForm();
  const onSubmit = data => console.log(data);

	return (
        <form onSubmit={handleSubmit(onSubmit)}>
            <div className={styledContainer }>
      <input
                {...register('query')}
                type="text"
                placeholder="Search for cakes..."
                className={styledInput }
                />
      </div>
    </form>
  );
}
const styledInput = " w-[500px] px-4 py-2 text-sm placeholder:text-stone-400  transition-all duration-300 focus:outline-none focus:ring focus:ring-pink focus:ring-opacity-50";
const styledContainer = "ml-24 mt-20 h-10 border border-[#fde4e4] rounded-md focus:outline-none w-[500px] ";
export default SearchBar

