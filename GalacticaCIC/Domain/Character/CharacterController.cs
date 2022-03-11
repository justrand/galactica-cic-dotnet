namespace GalacticaCIC.Domain.Character;

public class CharacterController: Controller
{
    private DataContext _dataContext;
    
    public CharacterController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public ActionResult GetCharacters()
    {
        return Ok();
    }
    
}
