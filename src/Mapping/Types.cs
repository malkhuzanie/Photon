namespace Photon.Mapping;

/*
 * an object used for validating model attributes
 * name: contains the name of the attribute
 * value: contains the value of the attribute
 */
public record ValidationArg(string Name, object? Value);

/*
 * status is true if validation succeeded
 * and msg is set to empty
 * otherwise msg contains the validation error
 */
public record ValidationResult(bool Status, string Msg);

/*
 * an object that represents the result of mapping 
 * from a Model to a Dto and vice versa
 * if the mapping is successful, msg is empty
 * and result contains the required object
 * else msg holds the mapping error 
 */
public record MappingResult<T>(string Msg, T? Result);
