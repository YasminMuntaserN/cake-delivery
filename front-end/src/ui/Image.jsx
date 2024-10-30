function Image({ src, alt, className, entity }) {
  const isUploadPath = typeof src === 'string' && src.includes(`/uploads/${entity}`);

  return (
    <>
      {!isUploadPath ? (
        <img src={src} alt={alt} className={className} />
      ) : (
        <img src={`https://localhost:7085${src}`} alt={alt} className={className} />
      )}
    </>
  );
}

export default Image;